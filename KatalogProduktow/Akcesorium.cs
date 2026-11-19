using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

namespace KatalogProduktow
{
    public class Akcesorium : Produkt
    {
        public string Kolor { get; set; }

        public override string Opis()
        {
            return $"Nazwa: {Nazwa}, Cena: {Cena}, Kolor: {Kolor}, Kategoria: {Kategoria}, " +
                 $"Ilość: {Ilosc}, Wartość magazynu: {WartoscMagazynu}";
        }
    }
}
