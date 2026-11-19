using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow
{
    public class Podzespol : Produkt 
        {
            public string Producent { get; set; } 
            public override string ToString()
            {
                return $"Nazwa: {Nazwa}, Cena: {Cena}, Kategoria: {Kategoria}, Ilość: {Ilosc}, Wartość magazynu: {WartoscMagazynu}, Producent: {Producent}";
            }
            public override string Opis()
            { 
                return $"Producent: {Producent}, Nazwa: {Nazwa}, Cena: {Cena}, Kategoria: {Kategoria}, " + $"Ilość: {Ilosc}, Wartość magazynu: {WartoscMagazynu}";
            }
        }
}
