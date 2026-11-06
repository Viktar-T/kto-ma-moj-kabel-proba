using KtoMaMojKabel.Logika;

namespace KtoMaMojKabel.Testy;

public class ListaPozyczekTesty
{
    // K2 — przeżywa błąd użytkownika: Kiedy zostawię puste pole „co” i kliknę „zapisz”,
    // to aplikacja zostaje na ekranie, nic nie dopisuje i mówi, że trzeba wpisać, co pożyczam.
    // Połowa z logiki: puste „co” nie jest dodawane.
    [Test]
    public void K2_puste_co_nie_jest_dodawane()
    {
        // Arrange
        var lista = new ListaPozyczek();
        var dzis = new DateOnly(2026, 11, 5);

        // Act
        var dodano = lista.Dodaj("   ", "osoba z pracowni", dzis);

        // Assert
        Assert.That(dodano, Is.False);
        Assert.That(lista.NaZewnatrz, Is.Empty);
    }

    // K4: Kiedy oznaczę pożyczkę jako zwróconą, to znika z listy rzeczy na zewnątrz,
    // a lista jest o jedną krótsza. Sprawdzenie: policzyć przed i po.
    [Test]
    public void K4_zwrot_skraca_liste_na_zewnatrz_o_jeden()
    {
        // Arrange
        var lista = new ListaPozyczek();
        lista.Dodaj("miernik", "osoba z pracowni", new DateOnly(2026, 11, 2));
        lista.Dodaj("zasilacz", "osoba z klubu", new DateOnly(2026, 11, 3));
        var przed = lista.NaZewnatrz.Count;

        // Act — zwrot pierwszej rzeczy z listy, tak jak zrobi to użytkownik
        lista.Zwroc(lista.NaZewnatrz[0].Co);

        // Assert
        Assert.That(lista.NaZewnatrz, Has.Count.EqualTo(przed - 1));
        Assert.That(lista.NaZewnatrz.Select(p => p.Co), Has.No.Member("miernik"));
    }

    // K5: Kiedy na liście są trzy pożyczki z różnymi datami, to najstarsza jest pierwsza.
    // Sprawdzenie: porównać daty od góry.
    [Test]
    public void K5_najstarsza_pozyczka_jest_pierwsza()
    {
        // Arrange
        var lista = new ListaPozyczek();
        lista.Dodaj("kabel HDMI", "ktoś z domu", new DateOnly(2026, 11, 4));
        lista.Dodaj("miernik", "osoba z pracowni", new DateOnly(2026, 11, 2));
        lista.Dodaj("zasilacz", "osoba z klubu", new DateOnly(2026, 11, 3));

        // Act
        var datyOdGory = lista.NaZewnatrz.Select(p => p.Kiedy).ToList();

        // Assert
        Assert.That(datyOdGory, Is.EqualTo(new[]
        {
            new DateOnly(2026, 11, 2), new DateOnly(2026, 11, 3), new DateOnly(2026, 11, 4),
        }));
    }
}
