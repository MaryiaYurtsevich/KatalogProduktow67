using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow
{
        public class Usluga : Produkt
        {
        public override string Status => "usługa";
        public override double WartoscMagazynu => 0;

        public override string ToString() => Opis();


            public override string Opis()
            {
                return $"{Nazwa} (usługa), Cena: {Cena:F2}";
            }

        public override int Ilosc
        {
            get => 0;
            set { }
        } 
        }
}
