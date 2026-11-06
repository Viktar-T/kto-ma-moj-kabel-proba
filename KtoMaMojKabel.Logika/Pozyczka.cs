namespace KtoMaMojKabel.Logika;

public record Pozyczka(string Co, string Komu, DateOnly Kiedy)
{
    public bool Zwrocona { get; init; }
}
