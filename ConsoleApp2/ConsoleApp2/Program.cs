using System;
using System.Collections.Generic;
using System.Text;

using KatalogProduktow;

List<Produkt> produkty = new List<Produkt>
        {
            new Produkt { Nazwa = "Panini", Cena = 15.00, Kategoria = "kategoria1", Ilosc = 5 },
            new Produkt { Nazwa = "Kawa", Cena = 17.50, Kategoria = "kategoria2", Ilosc = 3 },
            new Produkt { Nazwa = "Herbata", Cena = 67.00, Kategoria = "kategoria2", Ilosc = 8 },
            new Produkt { Nazwa = "Krewetka", Cena = 85.00, Kategoria = "kategoria1", Ilosc = 2 },
            new Produkt { Nazwa = "Kasza", Cena = 100.00, Kategoria = "kategoria1", Ilosc = 40 }

        };
//tworze slownik nazwa kategorii <-> lista produktów w tej kategorii
var produktyWKategoriach = new Dictionary<string, List<Produkt>>();
//idziemy po globalnej tablicy produktów   
foreach (var produkt in produkty)
{
    //sprawdzamy czy istnieje kategoria w slowniku o tej nazwie
    if (!produktyWKategoriach.ContainsKey(produkt.Kategoria))
    {
        //jesli nie istnieje to tworzymy nowa liste produktow w tej kategorii
        produktyWKategoriach[produkt.Kategoria] = new List<Produkt>();
    }
    //dodajemy produkt do listy produktow w tej kategorii
    produktyWKategoriach[produkt.Kategoria].Add(produkt);
}
//wypisz tylko produkty w kategorii "Jedzenie"
Console.WriteLine("Produkty w kategorii 'kategoria1':");
foreach (var produkt in produktyWKategoriach["kategoria1"])
{
    Console.WriteLine(produkt.Nazwa);
}

Console.WriteLine("Produkty w kategorii 'kategoria2':");
foreach (var produkt in produktyWKategoriach["kategoria2"])
{
    Console.WriteLine(produkt.Nazwa);
}

Console.WriteLine("Wszystkie produkty:");
foreach (var produkt in produkty)
{
    Console.WriteLine(produkt.Nazwa);
}
Console.WriteLine("Produkty o cenie mniejszej niż 20:");
foreach (var produkt in produkty.Where(produkt => produkt.Cena < 20))
{
    Console.WriteLine(produkt.Nazwa);
}
Console.WriteLine("Produkty posortowane według ceny:");
foreach (var produkt in produkty.OrderBy(produkt => produkt.Cena))
{
    Console.WriteLine(produkt.Nazwa);
}
//sprawdz wartosc na przykładzie pierwszego produktu
Produkt.SprawdzWartosc(produkty[0]);
//sprawdz ceny wszystkich produktów
Produkt.SprawdzCeny(produkty);


//28.10.2026
var produktyDziedziczone = new List<Produkt>
{
    new Produkt { Nazwa = "Produkt1", Cena = 10.0, Kategoria = "Kategoria1", Ilosc = 5 },
    new Podzespol { Nazwa = "Podzespol1", Cena = 25.0, Kategoria = "Kategoria2", Ilosc = 2, Producent = "Producent1" },
    new Akcesorium { Nazwa = "Akcesorium1", Cena = 15.0, Kategoria = "Kategoria2", Ilosc = 3, Kolor = "Czerwony" },
    new Usluga { Nazwa = "Usluga1", Cena = 20.0, Kategoria = "Kategoria3", Ilosc = 0 }
};
//który opis zobaczymy?
foreach (var produkt in produktyDziedziczone)
{
    Console.WriteLine(produkt.Opis());
}