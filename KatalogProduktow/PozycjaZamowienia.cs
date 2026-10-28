using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow
{
    public class PozycjaZamowienia
    {
        public Produkt Produkt { get; set; }
        public int Quantity { get; set; }

        public PozycjaZamowienia(Produkt produkt, int ilosc)
        {
            Produkt = produkt;
            Quantity = ilosc;
        }
        public double Wartosc => Produkt.Price * Quantity;
        public void DodajQuantity(int quantity) => Quantity += quantity;
    }
}
