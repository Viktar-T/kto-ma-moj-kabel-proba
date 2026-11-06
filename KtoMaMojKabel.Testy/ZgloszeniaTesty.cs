using KtoMaMojKabel.Logika;

namespace KtoMaMojKabel.Testy;

public class ZgloszeniaTesty
{
    // opinie/02-ktos-z-domu.md — zgłoszenie: kroki — zwrot ładowarki, zamknięcie, otwarcie;
    // co miało być widać — listę bez ładowarki, ładowarkę w historii;
    // co było widać — ładowarki nie ma nigdzie, także w historii.
    // Konstytucja, punkt 6: zwróconej rzeczy nie wolno skasować — znika z listy, zostaje w historii.
    [Test]
    public void Zgloszenie_02_zwrocona_pozyczka_zostaje_w_historii()
    {
        // Arrange — kroki
        var lista = new ListaPozyczek();
        lista.Dodaj("ładowarka", "ktoś z domu", new DateOnly(2026, 11, 4));

        // Act
        lista.Zwroc("ładowarka");

        // Assert — co miało być widać
        Assert.That(lista.NaZewnatrz, Is.Empty);
        Assert.That(lista.Historia, Has.Count.EqualTo(1));
        Assert.That(lista.Historia[0].Zwrocona, Is.True);
    }
}
