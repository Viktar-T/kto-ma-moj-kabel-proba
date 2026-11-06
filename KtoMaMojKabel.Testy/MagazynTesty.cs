using KtoMaMojKabel.Logika;

namespace KtoMaMojKabel.Testy;

public class MagazynTesty
{
    private string folder = "";
    private string plik = "";

    [SetUp]
    public void PrzedTestem()
    {
        folder = Directory.CreateTempSubdirectory("kabel-testy-").FullName;
        plik = Path.Combine(folder, "pozyczki.json");
    }

    [TearDown]
    public void PoTescie()
    {
        Directory.Delete(folder, recursive: true);
    }

    // K1 — pamięta po zamknięciu: Kiedy wpiszę trzy pożyczki i zamknę aplikację krzyżykiem,
    // to po ponownym otwarciu lista ma trzy pozycje z tymi samymi datami.
    [Test]
    public void K1_zapisane_pozyczki_wracaja_takie_same()
    {
        // Arrange
        var przed = new List<Pozyczka>
        {
            new("kabel HDMI; 2 m", "ktoś z domu", new DateOnly(2026, 11, 3)),
            new("miernik", "osoba z pracowni", new DateOnly(2026, 11, 4)) { Zwrocona = true },
            new("żółty zasilacz", "osoba z klubu", new DateOnly(2026, 11, 5)),
        };

        // Act
        Magazyn.Zapisz(plik, przed);
        var po = Magazyn.Wczytaj(plik);

        // Assert
        Assert.That(po, Is.EqualTo(przed));
        TestContext.Out.WriteLine(File.ReadAllText(plik));
    }

    [Test]
    public void Pusta_lista_wraca_pusta()
    {
        Magazyn.Zapisz(plik, new List<Pozyczka>());

        var po = Magazyn.Wczytaj(plik);

        Assert.That(po, Is.Empty);
    }

    // Pierwsze uruchomienie: pliku jeszcze nie ma.
    [Test]
    public void Brak_pliku_to_pusta_lista()
    {
        var po = Magazyn.Wczytaj(plik);

        Assert.That(po, Is.Empty);
    }

    // Zapis przerwany w połowie zostawia pusty plik.
    [Test]
    public void Pusty_plik_to_pusta_lista()
    {
        File.WriteAllText(plik, "");

        var po = Magazyn.Wczytaj(plik);

        Assert.That(po, Is.Empty);
    }
}
