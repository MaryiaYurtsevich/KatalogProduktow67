namespace MauiApp1;

using KatalogProduktow;
using System.Collections.ObjectModel;

public partial class MainPage : ContentPage
{
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
        BindingContext = this;
    }
    private void Button_Clicked(object sender, EventArgs e)
    {

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
    }

    private void UsunProdukt_Clicked(object sender, EventArgs e)
    {
        if (ProductsCollection.SelectedItem is Produkt wybranyProdukt)
        {
            Produkty.Remove(wybranyProdukt);
        }
    }

}

