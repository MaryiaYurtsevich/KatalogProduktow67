namespace MauiApp1;

using KatalogProduktow;
using System.Collections.ObjectModel;

public partial class MainPage : ContentPage
{
    // Stos stron przechowuje strony ktore otwieramy w aplikacji
    // PushAsync otwiera nową strone i dodaje ja na stos
    // PopAsync zamyka obecna strone i wraca do poprzedniej
    private readonly List<Produkt> bazaProduktow = new();
    public ObservableCollection<Produkt> widoczneProdukty { get; set; } = new ObservableCollection<Produkt>();
    public ObservableCollection<Produkt> Produkty { get; set; }
    public MainPage()
    {
        bazaProduktow = new List<Produkt>

        {
        new Produkt { Nazwa = "Panini", Cena = 15.00, Kategoria = "Jedzenie", Ilosc = 5 },
        new Produkt { Nazwa = "Kawa", Cena = 17.50, Kategoria = "Napoje", Ilosc = 3 },
        new Produkt { Nazwa = "Herbata", Cena = 67.00, Kategoria = "Napoje", Ilosc = 8 },
        new Produkt { Nazwa = "Krewetka", Cena = 85.00, Kategoria = "Jedzenie", Ilosc = 2 },
        new Produkt { Nazwa = "Kasza", Cena = 100.00, Kategoria = "Jedzenie", Ilosc = 40 },


        new Podzespol
        {
            Nazwa = "Procesor",
            Cena = 250.00,
            Kategoria = "Elektronika",
            Ilosc = 10,
        },
        new Usluga
        {
            Nazwa = "Naprawa komputera",
            Cena = 150.00,
            Kategoria = "Usługi",
            Ilosc = 0,
        }
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
        string nazwa = nazwaEntry.Text ?? "";
        if (!double.TryParse(cenaEntry.Text, out double cena) || cena < 0)
        {
            return;
        }
        string kategoria = kategoriaPicker.SelectedItem?.ToString() ?? "";

        //tworzymy nową instancję produktu
        Produkt nowyProdukt = new Produkt
        {
            Nazwa = nazwa,
            Cena = cena,
            Kategoria = kategoria,
            Ilosc = 0 // domyślna ilość
        };
        bazaProduktow.Add(nowyProdukt);
        Odswiez();
    }


    private void UsunProdukt_Clicked(object sender, EventArgs e)
    {
        if (ProductsCollection.SelectedItem is Produkt wybranyProdukt)
        {
            bazaProduktow.Remove(wybranyProdukt);
        }
            Odswiez();
        }
    


    private void OnSearchButtonClicked(object sender, EventArgs e)
    {
        Odswiez();
    }
    private void nameSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        Odswiez();
    }

    //roznica miedzy PushAsync a GoToAsync jest taka, ze PushAsync jest uzywane w tradycyjnej nawigacji stron, podczas gdy GoToAsync jest uzywane w nawigacji opartej na Shell. GoToAsync pozwala na przechodzenie do stron zdefiniowanych w Shell i przekazywanie parametrów w bardziej elastyczny sposob.

    //private async void Szczegoly_Clicked(object sender, EventArgs e)
    //{
    //    if (ProductsCollection.SelectedItem is Produkt wybrany)
    //    {
    //        // połóż nową stronę na stos i przekaż jej zaznaczony produkt
    //        await Navigation.PushAsync(new SzczegolyPage(wybrany));
    //    }
    //    else
    //    {
    //        await DisplayAlertAsync("Brak wyboru", "Najpierw zaznacz produkt na liście.", "OK");
    //    }

    //}

    private async void Szczegoly_Clicked(object sender, EventArgs e)
    {
        if (ProductsCollection.SelectedItem is Produkt wybranyProdukt)
        {// Przekazanie wybranego produktu do strony szczegółów
         // przygotowanie paczki z danymi do przekazania
            var dane = new Dictionary<string, object>
                {
                    { "Produkt", wybranyProdukt },
                    { "BazaProduktow", bazaProduktow }
                };
            //wywołanie nawigacji do strony szczegółów z przekazaniem danych
            await Shell.Current.GoToAsync(nameof(SzczegolyPage), dane);
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Odswiez();
    }

}

