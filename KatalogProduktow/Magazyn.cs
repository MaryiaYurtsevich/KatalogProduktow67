using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow
{
    public class Magazyn
    {
        public static double wartoscMagazynu(IEnumerable<Produkt> produkty)
        {
            //zwroc sume sum wartosci magazynowej wszystkich produktow w magazynie
            return produkty.Sum(p => p.WartoscMagazynu);
        }
    }
}
