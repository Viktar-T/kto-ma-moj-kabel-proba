using KtoMaMojKabel.Logika;
using Microsoft.Data.Sqlite;

namespace KtoMaMojKabel.Testy;

public class MagazynSqliteTesty
{
    private SqliteConnection polaczenie = null!;
    private MagazynSqlite magazyn = null!;

    [SetUp]
    public void PrzedTestem()
    {
        polaczenie = new SqliteConnection("Data Source=:memory:");
        polaczenie.Open();
        magazyn = new MagazynSqlite(polaczenie);
        magazyn.Dodaj(new Pozyczka("miernik", "osoba z pracowni", new DateOnly(2026, 11, 4)));
        magazyn.Dodaj(new Pozyczka("żółty zasilacz", "ktoś z klubu 'Elektron'", new DateOnly(2026, 11, 5)));
    }

    [TearDown]
    public void PoTescie()
    {
        polaczenie.Dispose();
    }

    // K1 — pamięta po zamknięciu, w wersji 2: to, co zapisano, wraca takie samo.
    [Test]
    public void K1_zapisane_pozyczki_wracaja_takie_same()
    {
        var wszystkie = magazyn.Wszystkie();

        Assert.That(wszystkie, Has.Count.EqualTo(2));
        Assert.That(wszystkie[1], Is.EqualTo(new Pozyczka("żółty zasilacz", "ktoś z klubu 'Elektron'", new DateOnly(2026, 11, 5))));
    }

    [Test]
    public void Baza_w_pamieci_znika_po_zamknieciu_polaczenia()
    {
        polaczenie.Dispose();
        using var nowe = new SqliteConnection("Data Source=:memory:");
        nowe.Open();
        using var polecenie = nowe.CreateCommand();
        polecenie.CommandText = "SELECT COUNT(*) FROM Pozyczki";

        var wyjatek = Assert.Throws<SqliteException>(() => polecenie.ExecuteScalar());

        TestContext.Out.WriteLine(wyjatek!.Message);
        Assert.That(wyjatek.Message, Does.Contain("no such table"));
    }

    [Test]
    public void Apostrof_w_nazwie_z_parametrem_znajduje_wiersz()
    {
        var znalezione = magazyn.Szukaj("ktoś z klubu 'Elektron'");

        Assert.That(znalezione, Has.Count.EqualTo(1));
    }

    [Test]
    public void Apostrof_w_nazwie_psuje_zapytanie_sklejane()
    {
        var wyjatek = Assert.Throws<SqliteException>(() => magazyn.SzukajSklejane("ktoś z klubu 'Elektron'"));

        TestContext.Out.WriteLine(wyjatek!.Message);
        Assert.That(wyjatek.Message, Does.Contain("syntax error"));
    }

    [Test]
    public void Wstrzykniecie_zwraca_wszystko_tylko_w_zapytaniu_sklejanym()
    {
        var zParametrem = magazyn.Szukaj("x' OR '1'='1");
        var sklejane = magazyn.SzukajSklejane("x' OR '1'='1");

        Assert.That(zParametrem, Is.Empty);
        Assert.That(sklejane, Has.Count.EqualTo(2));
    }

    [Test]
    public void Wstrzykniecie_usuwa_tabele_tylko_w_zapytaniu_sklejanym()
    {
        magazyn.Szukaj("x'; DROP TABLE Pozyczki; --");
        Assert.That(magazyn.Policz(), Is.EqualTo(2));

        magazyn.SzukajSklejane("x'; DROP TABLE Pozyczki; --");
        var wyjatek = Assert.Throws<SqliteException>(() => magazyn.Policz());

        TestContext.Out.WriteLine(wyjatek!.Message);
        Assert.That(wyjatek.Message, Does.Contain("no such table"));
    }
}
