using System;
using System.Collections.Generic;
using System.Text;

using KatalogProduktow;

List<Produkt> produkty = new List<Produkt>
        {
            new Produkt { Name = "Panini", Price = 15.00, Category = "kategoria1", Quantity = 5 },
            new Produkt { Name = "Kawa", Price = 17.50, Category = "kategoria2", Quantity = 3 },
            new Produkt { Name = "Herbata", Price = 67.00, Category = "kategoria2", Quantity = 8 },
            new Produkt { Name = "Krewetka", Price = 85.00, Category = "kategoria1", Quantity = 2 },
            new Produkt { Name = "Kasza", Price = 100.00, Category = "kategoria1", Quantity = 40 }

        };
//tworze slownik nazwa kategorii <-> lista produktów w tej kategorii
var produktyWKategoriach = new Dictionary<string, List<Produkt>>();
//idziemy po globalnej tablicy produktów   
foreach (var produkt in produkty)
{
    //sprawdzamy czy istnieje kategoria w slowniku o tej nazwie
    if (!produktyWKategoriach.ContainsKey(produkt.Category))
    {
        //jesli nie istnieje to tworzymy nowa liste produktow w tej kategorii
        produktyWKategoriach[produkt.Category] = new List<Produkt>();
    }
    //dodajemy produkt do listy produktow w tej kategorii
    produktyWKategoriach[produkt.Category].Add(produkt);
}
//wypisz tylko produkty w kategorii "Jedzenie"
Console.WriteLine("Produkty w kategorii 'kategoria1':");
foreach (var produkt in produktyWKategoriach["kategoria1"])
{
    Console.WriteLine(produkt.Name);
}

Console.WriteLine("Produkty w kategorii 'kategoria2':");
foreach (var produkt in produktyWKategoriach["kategoria2"])
{
    Console.WriteLine(produkt.Name);
}

Console.WriteLine("Wszystkie produkty:");
foreach (var produkt in produkty)
{
    Console.WriteLine(produkt.Name);
}
Console.WriteLine("Produkty o cenie mniejszej niż 20:");
foreach (var produkt in produkty.Where(produkt => produkt.Price < 20))
{
    Console.WriteLine(produkt.Name);
}
Console.WriteLine("Produkty posortowane według ceny:");
foreach (var produkt in produkty.OrderBy(produkt => produkt.Price))
{
    Console.WriteLine(produkt.Name);
}
//sprawdz wartosc na przykładzie pierwszego produktu
Produkt.SprawdzWartosc(produkty[0]);
//sprawdz ceny wszystkich produktów
Produkt.SprawdzCeny(produkty);


//28.10.2026
var produktyDziedziczone = new List<Produkt>
{
    new Produkt { Name = "Produkt1", Price = 10.0, Category = "Kategoria1", Quantity = 5 },
    new Podzespol { Name = "Podzespol1", Price = 25.0, Category = "Kategoria2", Quantity = 2, Producent = "Producent1" },
    //new Akcesorium { Name = "Akcesorium1", Price = 15.0, Category = "Kategoria2", Quantity = 3, Kolor = "Czerwony" },
    new Usluga { Name = "Usluga1", Price = 20.0, Category = "Kategoria3", Quantity = 0 }
};
//który opis zobaczymy?
foreach (var produkt in produktyDziedziczone)
{
    Console.WriteLine(produkt.Opis());
}