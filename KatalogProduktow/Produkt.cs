using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow
{
    public class Produkt
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Category { get; set; }
        public int Quantity { get; set; }
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
    }
 }