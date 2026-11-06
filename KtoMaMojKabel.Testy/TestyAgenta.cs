using KtoMaMojKabel.Logika;

namespace KtoMaMojKabel.Testy;

public class TestyAgenta
{
    // K3: Kiedy wpiszę „miernik”, „osoba z pracowni” i dzisiejszą datę i kliknę „zapisz”,
    // to pozycja jest na liście z tą datą.
    [Test]
    public void K3_dodana_pozycja_jest_na_liscie_z_data()
    {
        var lista = new ListaPozyczek();
        var dzis = new DateOnly(2026, 11, 5);

        lista.Dodaj("miernik", "osoba z pracowni", dzis);

        Assert.That(lista.NaZewnatrz, Has.Count.EqualTo(1));
        Assert.That(lista.NaZewnatrz[0].Co, Is.EqualTo("miernik"));
        Assert.That(lista.NaZewnatrz[0].Kiedy, Is.EqualTo(dzis));
    }

    // K6: Kiedy nie ma żadnej pożyczki, to lista mówi, że nic nie jest na zewnątrz.
    [Test]
    public void K6_pusta_lista_mowi_ze_nic_nie_jest_na_zewnatrz()
    {
        var lista = new ListaPozyczek();

        Assert.That(lista.JestPusto, Is.True);
        Assert.That(lista.Komunikat, Is.EqualTo("Nic nie jest na zewnątrz."));
    }

    // K5 (dopowiedzenie): przy tej samej dacie w kolejności wpisania.
    [Test]
    public void K5_przy_tej_samej_dacie_kolejnosc_wpisania()
    {
        var lista = new ListaPozyczek();
        var dzis = new DateOnly(2026, 11, 5);
        lista.Dodaj("miernik", "osoba z pracowni", dzis);
        lista.Dodaj("zasilacz", "osoba z klubu", dzis);

        var kolejnosc = lista.NaZewnatrz;

        Assert.That(kolejnosc.Select(p => p.Co), Is.EqualTo(new[] { "miernik", "zasilacz" }));
    }
}
