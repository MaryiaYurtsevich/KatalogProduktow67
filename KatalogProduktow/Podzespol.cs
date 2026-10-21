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
                return $"Nazwa: {Name}, Cena: {Price}, Kategoria: {Category}, Ilość: {Quantity}, Wartość magazynu: {WartoscMagazynu}, Producent: {Producent}";
            }
            public override string Opis()
            { 
                return $"Producent: {Producent}, Nazwa: {Name}, Cena: {Price}, Kategoria: {Category}, " + $"Ilość: {Quantity}, Wartość magazynu: {WartoscMagazynu}";
            }
        }
}
