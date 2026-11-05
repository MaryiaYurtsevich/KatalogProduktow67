namespace MauiApp1;

using KatalogProduktow;
using System.Collections.ObjectModel;

public partial class MainPage : ContentPage
{
    private readonly List<Produkt> bazaProduktow = new();
    public ObservableCollection<Produkt> widoczneProdukty { get; set; } = new ObservableCollection<Produkt>();
    public ObservableCollection<Produkt> Produkty { get; set; }
    public MainPage()
    {
        Produkty = new ObservableCollection<Produkt>

        {
        new Produkt { Name = "Panini", Price = 15.00, Category = "Jedzenie", Quantity = 5 },
        new Produkt { Name = "Kawa", Price = 17.50, Category = "Napoje", Quantity = 3 },
        new Produkt { Name = "Herbata", Price = 67.00, Category = "Napoje", Quantity = 8 },
        new Produkt { Name = "Krewetka", Price = 85.00, Category = "Jedzenie", Quantity = 2 },
        new Produkt { Name = "Kasza", Price = 100.00, Category = "Jedzenie", Quantity = 40 }

    };
        InitializeComponent();
        Odswiez();
        BindingContext = this;
    }
    private void Odswiez()
    {
        widoczneProdukty.Clear();
        string kryteria = nameSearchBar.Text ?? string.Empty;
        List<Produkt> znalezioneProdukty = Produkt.Szukaj(bazaProduktow, kryteria);
        foreach (var produkt in znalezioneProdukty)
        {
            widoczneProdukty.Add(produkt);
        }
        iloscLabel.Text = $"Ilość produktów: {widoczneProdukty.Count}";
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        Odswiez();
    }
    private void DodajProdukt_Clicked(object sender, EventArgs e)
    {
        //odczytujemy wartości z pól tekstowych
        string nazwa = nazwaEntry.Text;
        double cena = double.Parse(cenaEntry.Text);
        string kategoria = kategoriaPicker.SelectedItem.ToString();

        //tworzymy nową instancję produktu
        Produkt nowyProdukt = new Produkt
        {
            Name = nazwa,
            Price = cena,
            Category = kategoria,
            Quantity = 0 // domyślna ilość
        };
        Produkty.Add(nowyProdukt);
        Odswiez();
    }

    private void UsunProdukt_Clicked(object sender, EventArgs e)
    {
        if (ProductsCollection.SelectedItem is Produkt wybranyProdukt)
        {
            Produkty.Remove(wybranyProdukt);
        }
    }

    private void OnSearchButtonClicked(object sender, EventArgs e)
    {
        string nazwa = nazwaEntry.Text?.Trim() ?? "";

        var wyniki = Produkty.Where(p =>
            p.Name.Contains(nazwa, StringComparison.OrdinalIgnoreCase));

        ProductsCollection.ItemsSource = wyniki.ToList();

    }
    private void nameSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        Odswiez();
    }

}

