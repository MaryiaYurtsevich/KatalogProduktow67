using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

namespace KatalogProduktow
{
    internal class Akcesorium
    {
        public string Kolor { get; set; }

        public override string Opis()
        {
            return $"Nazwa: {Name}, Cena: {Price}, Kolor: {Color}, Kategoria: {Category}, " +
                 $"Ilość: {Quantity}, Wartość magazynu: {WartoscMagazynu}";
        }
    }
}
