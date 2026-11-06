using System.Text.Json;

namespace KtoMaMojKabel.Logika;

public static class Magazyn
{
    public static void Zapisz(string sciezka, IReadOnlyList<Pozyczka> pozyczki)
        => File.WriteAllText(sciezka, JsonSerializer.Serialize(pozyczki));

    public static List<Pozyczka> Wczytaj(string sciezka)
    {
        if (!File.Exists(sciezka)) return new();
        var tekst = File.ReadAllText(sciezka);
        return JsonSerializer.Deserialize<List<Pozyczka>>(tekst) ?? new();
    }
}
