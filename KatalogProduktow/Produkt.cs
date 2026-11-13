using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Text;

namespace KatalogProduktow
{
    public class Produkt : IWyceniany, IComparable<Produkt>
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Category { get; set; }
        public int Quantity { get; set; }

        public virtual string Status =>
            Quantity == 0 ? "brak" :
            Quantity < 5 ? "ostatnie sztuki" :
            "dostępny";


        public virtual double WartoscMagazynu
        {
            get { return Price * Quantity; }
        }
        //funkcja sprawdza czy poprawnie obliczamy wartośc magazynu
        public static void SprawdzWartosc(Produkt p)
        {

            if (p.WartoscMagazynu == p.Price * p.Quantity)
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
                if (produkt.Price < 0)
                {
                    Console.WriteLine($"Produkt {produkt.Name} ma niepoprawną cenę: {produkt.Price}");
                }
            }
        }

        public override string ToString()
        {
            return $"Nazwa: {Name}, Cena: {Price}, Kategoria: {Category}, " +
                $"Ilość: {Quantity}, Wartość magazynu: {WartoscMagazynu}";
        }
        //funkcja zwraca opis produktu
        public virtual string Opis()
        {
            return $"Nazwa: {Name}, Cena: {Price}, Kategoria: {Category}, " +
                $"Ilość: {Quantity}, Wartość magazynu: {WartoscMagazynu}";
        }
        public int CompareTo(Produkt? other)
        {
            //jeśli drugi obiekt jest null, to ten obiekt jest większy (bo 1 > 0)
            if (other == null) return 1;
            //w innym wypadku zwracamy wynik porównania cen produktów
            return this.Price.CompareTo(other.Price);
        }
        public static List<Produkt> Szukaj(List<Produkt> produkty, string nazwa)
        {
            List<Produkt> znalezioneProdukty = new List<Produkt>();
            //można pętlą foreach przeszukać listę produktów i dodać do znalezioneProdukty te, które zawierają w nazwie szukany ciąg znaków
            foreach (var produkt in produkty)
            {
                if (produkt.Name.Contains(nazwa, StringComparison.OrdinalIgnoreCase))
                {
                    znalezioneProdukty.Add(produkt);
                }
            }
            //alternatywnie można użyć LINQ do wyszukiwania produktów:
            znalezioneProdukty.Clear(); //czyścimy listę, żeby nie dublować wyników
            znalezioneProdukty = produkty.Where(p => p.Name.Contains(nazwa, StringComparison.OrdinalIgnoreCase)).ToList();
            //zwracamy listę znalezionych produktów
            return znalezioneProdukty;
        }

    }
}