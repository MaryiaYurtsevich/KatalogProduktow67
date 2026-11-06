using KatalogProduktow;

namespace MauiApp1;

public partial class SzczegolyPage : ContentPage, IQueryAttributable
{
    // konstruktor dla Shell - dane przyjdą później, w ApplyQueryAttributes
    public SzczegolyPage()
    {
        InitializeComponent();
    }

    // Shell wywołuje tę metodę i podaje słownik przekazany w GoToAsync
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["Produkt"] is Produkt produkt)
        {
            BindingContext = produkt;
            opisLabel.Text = produkt.Opis();
        }
    }
    // ... konstruktor z parametrem i Wroc_Clicked bez zmian
    private async void Wroc_Clicked(object sender, EventArgs e)
    {
        // zdejmij tę stronę ze stosu - wracamy do poprzedniej
        await Navigation.PopAsync();
    }

}