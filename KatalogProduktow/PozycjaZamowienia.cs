using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow
{
    public class PozycjaZamowienia
    {
        public IWyceniany Produkt { get; set; }
        public int Ilosc { get; set; }

        public PozycjaZamowienia(IWyceniany produkt, int ilosc)
        {
            Produkt = produkt;
            Ilosc = ilosc;
        }
        public double Wartosc => Produkt.Cena * Ilosc;
        public void DodajQuantity(int ilosc) => Ilosc += ilosc;
    }
}
