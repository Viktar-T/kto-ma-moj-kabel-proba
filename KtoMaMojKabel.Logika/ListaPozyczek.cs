namespace KtoMaMojKabel.Logika;

public class ListaPozyczek
{
    private readonly List<Pozyczka> pozyczki = new();

    public ListaPozyczek() { }

    public ListaPozyczek(IEnumerable<Pozyczka> zapisane)
    {
        pozyczki.AddRange(zapisane);
    }

    public IReadOnlyList<Pozyczka> Historia => pozyczki;

    public IReadOnlyList<Pozyczka> NaZewnatrz =>
        pozyczki.Where(p => !p.Zwrocona).OrderBy(p => p.Kiedy).ToList();

    public bool JestPusto => NaZewnatrz.Count == 0;

    public string Komunikat =>
        JestPusto ? "Nic nie jest na zewnątrz." : $"Na zewnątrz: {NaZewnatrz.Count}";

    public bool Dodaj(string co, string komu, DateOnly kiedy)
    {
        if (string.IsNullOrWhiteSpace(co)) return false;
        pozyczki.Add(new Pozyczka(co.Trim(), komu.Trim(), kiedy));
        return true;
    }

    public bool Zwroc(string co)
    {
        var i = pozyczki.FindIndex(p => p.Co == co && !p.Zwrocona);
        if (i < 0) return false;
        pozyczki.RemoveAt(i);
        return true;
    }
}
