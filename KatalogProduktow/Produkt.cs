using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Text;

namespace KatalogProduktow
{
    public class Produkt : IWyceniany, IComparable<Produkt>, INotifyPropertyChanged
    {
        private string? nazwa;
        public string? Nazwa
        {
            get => nazwa;
            set
            {
                nazwa = value;
                Zmiana(nameof(Nazwa));
            }
        }

        private double cena;
        public double Cena
        {
            get => cena;
            set
            {
                cena = value;
                Zmiana(nameof(Cena));
                Zmiana(nameof(WartoscMagazynu));
            }
        }

        private string? kategoria;
        public string? Kategoria
        {
            get => kategoria;
            set
            {
                kategoria = value;
                Zmiana(nameof(Kategoria));
            }
        }

        private int ilosc;
        public virtual int Ilosc
        {
            get => ilosc;
            set
            {
                ilosc = value;
                Zmiana(nameof(Ilosc));
                Zmiana(nameof(Status));
                Zmiana(nameof(WartoscMagazynu));
            }
        }

        public virtual string Status =>
            Ilosc == 0 ? "brak" :
            Ilosc < 5 ? "ostatnie sztuki" :
            "dostępny";


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void Zmiana(string nazwaWlasciwosci)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwaWlasciwosci));
        }
        public virtual double WartoscMagazynu
        {
            get { return Cena * Ilosc; }
        }
        //funkcja sprawdza czy poprawnie obliczamy wartośc magazynu
        public static void SprawdzWartosc(Produkt p)
        {

            if (p.WartoscMagazynu == p.Cena * p.Ilosc)
            {
                Console.WriteLine("Wartość magazynu jest poprawna.");
            }
            else
            {
                Console.WriteLine("Wartość magazynu jest niepoprawna.");
            }
        }
        //funkcja sprawdza czy cena produktu jest poprawna (nieujemna)
        public static void SprawdzCeny(List<Produkt> produkty)
        {
            foreach (var produkt in produkty)
            {
                if (produkt.Cena < 0)
                {
                    Console.WriteLine($"Produkt {produkt.Nazwa} ma niepoprawną cenę: {produkt.Cena}");
                }
            }
        }

        public override string ToString()
        {
            return $"Nazwa: {Nazwa}, Cena: {Cena}, Kategoria: {Kategoria}, " +
                $"Ilość: {Ilosc}, Wartość magazynu: {WartoscMagazynu}";
        }
        //funkcja zwraca opis produktu
        public virtual string Opis()
        {
            return $"Nazwa: {Nazwa}, Cena: {Cena}, Kategoria: {Kategoria}, " +
                $"Ilość: {Ilosc}, Wartość magazynu: {WartoscMagazynu}";
        }
        public int CompareTo(Produkt? other)
        {
            //jeśli drugi obiekt jest null, to ten obiekt jest większy (bo 1 > 0)
            if (other == null) return 1;
            //w innym wypadku zwracamy wynik porównania cen produktów
            return this.Cena.CompareTo(other.Cena);
        }
        public static List<Produkt> Szukaj(List<Produkt> produkty, string nazwa)
        {
            List<Produkt> znalezioneProdukty = new List<Produkt>();
            //można pętlą foreach przeszukać listę produktów i dodać do znalezioneProdukty te, które zawierają w nazwie szukany ciąg znaków
            foreach (var produkt in produkty)
            {
                if (produkt.Nazwa.Contains(nazwa, StringComparison.OrdinalIgnoreCase))
                {
                    znalezioneProdukty.Add(produkt);
                }
            }
            //alternatywnie można użyć LINQ do wyszukiwania produktów:
            znalezioneProdukty.Clear(); //czyścimy listę, żeby nie dublować wyników
            znalezioneProdukty = produkty.Where(p => p.Nazwa.Contains(nazwa, StringComparison.OrdinalIgnoreCase)).ToList();
            //zwracamy listę znalezionych produktów
            return znalezioneProdukty;
        }

    }
}