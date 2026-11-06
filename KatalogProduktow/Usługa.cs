using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow
{
        public class Usluga : Produkt
        {
        public override string Status => "usługa";
        public override double WartoscMagazynu => 0;


            public override string Opis()
            {
                return $"{Name} (usługa), Cena: {Price:F2}";
            }
        }
}
