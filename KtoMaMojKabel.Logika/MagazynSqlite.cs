using Microsoft.Data.Sqlite;

namespace KtoMaMojKabel.Logika;

public class MagazynSqlite
{
    private readonly SqliteConnection polaczenie;

    public MagazynSqlite(SqliteConnection polaczenie)
    {
        this.polaczenie = polaczenie;
        using var polecenie = polaczenie.CreateCommand();
        polecenie.CommandText =
            "CREATE TABLE IF NOT EXISTS Pozyczki (Co TEXT NOT NULL, Komu TEXT NOT NULL, Kiedy TEXT NOT NULL, Zwrocona INTEGER NOT NULL)";
        polecenie.ExecuteNonQuery();
    }

    public void Dodaj(Pozyczka p)
    {
        using var polecenie = polaczenie.CreateCommand();
        polecenie.CommandText =
            "INSERT INTO Pozyczki (Co, Komu, Kiedy, Zwrocona) VALUES ($co, $komu, $kiedy, $zwrocona)";
        polecenie.Parameters.AddWithValue("$co", p.Co);
        polecenie.Parameters.AddWithValue("$komu", p.Komu);
        polecenie.Parameters.AddWithValue("$kiedy", p.Kiedy.ToString("yyyy-MM-dd"));
        polecenie.Parameters.AddWithValue("$zwrocona", p.Zwrocona ? 1 : 0);
        polecenie.ExecuteNonQuery();
    }

    public List<Pozyczka> Wszystkie()
    {
        using var polecenie = polaczenie.CreateCommand();
        polecenie.CommandText = "SELECT Co, Komu, Kiedy, Zwrocona FROM Pozyczki ORDER BY rowid";
        return Czytaj(polecenie);
    }

    public List<Pozyczka> Szukaj(string komu)
    {
        using var polecenie = polaczenie.CreateCommand();
        polecenie.CommandText = "SELECT Co, Komu, Kiedy, Zwrocona FROM Pozyczki WHERE Komu = $komu";
        polecenie.Parameters.AddWithValue("$komu", komu);
        return Czytaj(polecenie);
    }

    // The shape to find and remove in an agent's code: the value glued into the text of the query.
    public List<Pozyczka> SzukajSklejane(string komu)
    {
        using var polecenie = polaczenie.CreateCommand();
        polecenie.CommandText = "SELECT Co, Komu, Kiedy, Zwrocona FROM Pozyczki WHERE Komu = '" + komu + "'";
        return Czytaj(polecenie);
    }

    public long Policz()
    {
        using var polecenie = polaczenie.CreateCommand();
        polecenie.CommandText = "SELECT COUNT(*) FROM Pozyczki";
        return (long)polecenie.ExecuteScalar()!;
    }

    private static List<Pozyczka> Czytaj(SqliteCommand polecenie)
    {
        var wynik = new List<Pozyczka>();
        using var czytnik = polecenie.ExecuteReader();
        while (czytnik.Read())
        {
            wynik.Add(new Pozyczka(czytnik.GetString(0), czytnik.GetString(1), DateOnly.Parse(czytnik.GetString(2)))
            {
                Zwrocona = czytnik.GetInt64(3) == 1
            });
        }
        return wynik;
    }
}
