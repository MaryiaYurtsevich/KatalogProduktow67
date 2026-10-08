namespace MauiApp1;

using KatalogProduktow;
public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();

        List<Produkt> produkty = new List<Produkt>

        {
        new Produkt { Name = "Panini", Price = 15.00, Category = "Jedzenie", Quantity = 5 },
        new Produkt { Name = "Kawa", Price = 17.50, Category = "Napoje", Quantity = 3 },
        new Produkt { Name = "Herbata", Price = 6767.00, Category = "Napoje", Quantity = 8 },
        new Produkt { Name = "Krewetka", Price = 8500.00, Category = "Jedzenie", Quantity = 2 },
        new Produkt { Name = "Kasza", Price = 100.00, Category = "Jedzenie", Quantity = 40 }

    };
        BindingContext = this;
        ProductsCollection.ItemsSource = produkty;

    }
}

    