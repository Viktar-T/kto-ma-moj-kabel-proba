using System;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using KtoMaMojKabel.Logika;

namespace KtoMaMojKabel.Desktop;

public partial class MainWindow : Window
{
    private readonly string sciezkaDanych;
    private readonly ListaPozyczek lista;

    public MainWindow() : this(DomyslnaSciezka()) { }

    public MainWindow(string sciezkaDanych)
    {
        InitializeComponent();
        this.sciezkaDanych = sciezkaDanych;
        lista = new ListaPozyczek(Magazyn.Wczytaj(sciezkaDanych));
        Odswiez();
    }

    private static string DomyslnaSciezka()
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        return Path.Combine(folder, "KtoMaMojKabel", "pozyczki.json");
    }

    private void Zapisz_Click(object? sender, RoutedEventArgs e)
    {
        var dodano = lista.Dodaj(CoPole.Text ?? "", KomuPole.Text ?? "", DateOnly.FromDateTime(DateTime.Today));
        Blad.Text = dodano ? "" : "Wpisz, co pożyczasz.";
        if (dodano)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(sciezkaDanych)!);
            Magazyn.Zapisz(sciezkaDanych, lista.Historia);
            CoPole.Text = "";
            KomuPole.Text = "";
        }
        Odswiez();
    }

    private void Odswiez()
    {
        Komunikat.Text = lista.Komunikat;
        Lista.ItemsSource = lista.NaZewnatrz.Select(p => $"{p.Co} — {p.Komu} — {p.Kiedy:yyyy-MM-dd}").ToList();
    }
}
