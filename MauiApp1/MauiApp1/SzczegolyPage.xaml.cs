using KatalogProduktow;

namespace MauiApp1;

public partial class SzczegolyPage : ContentPage, IQueryAttributable
{
    // konstruktor dla Shell - dane przyjdą później, w ApplyQueryAttributes
    private Produkt? produkt;
    private List<Produkt> baza;
    public SzczegolyPage()
    {
        InitializeComponent();

    }

    // Shell wywołuje tę metodę i podaje słownik przekazany w GoToAsync
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["Produkt"] is not Produkt produkt)
            return;
        this.produkt = produkt;
        if (query["BazaProduktow"] is not List<Produkt> baza)
            return;
        this.baza = baza;
        this.produkt = produkt;
        BindingContext = produkt;
        NazwaEntry.Text = produkt.Name;
        CenaEntry.Text = produkt.Price.ToString();
        IloscEntry.Text = produkt.Quantity.ToString();
        //KategoriaPicker.SelectedItem = produkt.Kategoria;
    }
    // ... konstruktor z parametrem i Wroc_Clicked bez zmian
    private async void Wroc_Clicked(object sender, EventArgs e)
    {
        // zdejmij tę stronę ze stosu - wracamy do poprzedniej
        await Shell.Current.GoToAsync("..");
    }
    private async void Zapisz_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NazwaEntry.Text))
        {
            await DisplayAlertAsync("Błąd", "Nazwa produktu nie może być pusta.", "OK");
            return;
        }
        if (!double.TryParse(CenaEntry.Text, out double cena) || cena < 0)
        {
            await DisplayAlertAsync("Błąd", "Cena produktu musi być liczbą nieujemną.", "OK");
            return;
        }
        if (!int.TryParse(IloscEntry.Text, out int ilosc) || ilosc < 0)
        {
            await DisplayAlertAsync("Błąd", "Ilość produktu musi być liczbą nieujemną.", "OK");
            return;
        }

        produkt.Name = NazwaEntry.Text;
        produkt.Price = cena;
        produkt.Quantity = ilosc;
        await Shell.Current.GoToAsync("..");
    }
    private async void Usun_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlertAsync("Potwierdzenie", "Czy na pewno chcesz usunąć produkt?", "Tak", "Nie");
        if (!answer)
        {
            return;
        }
        if (produkt is not null && baza is not null)
        {
            baza.Remove(produkt);
        }
        await Shell.Current.GoToAsync("..");
    }
}