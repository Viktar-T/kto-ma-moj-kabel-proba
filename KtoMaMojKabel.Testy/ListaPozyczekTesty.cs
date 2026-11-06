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
}
