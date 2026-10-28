using KatalogProduktow;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        List<Produkt> PrzygotujListeProduktów()
        {
            Random r = new Random();
            var produkty = new List<Produkt>();
            for (int i = 0; i < 10000; i++)
            {
                Produkt p = new Produkt
                {
                    Name = $"Produkt{i}",
                    Price = r.NextDouble() * 100,
                    Category = $"Kategoria{r.Next(1, 5)}",
                    Quantity = r.Next(1, 20)
                };
                produkty.Add(p);
            }
            return produkty;
        }
        Produkt PrzygotujProdukt()
        {
            Random r = new Random();
            Produkt p = new Produkt
            {
                Name = $"ProduktTestowy",
                Price = r.NextDouble() * 100,
                Category = $"Kategoria{r.Next(1, 5)}",
                Quantity = r.Next(1, 20)
            };
            return p;
        }
        [TestMethod]
        public void Produkt_SprawdzWartoscMagazynu()
        {
            // Arrange
            var produkt = PrzygotujProdukt();
            double sprawdzonaWartosc = produkt.Price * produkt.Quantity;
            // Act
            double wartoscMagazynu = produkt.WartoscMagazynu;
            // Assert
            Assert.AreEqual(sprawdzonaWartosc, wartoscMagazynu, "Wartość magazynu powinna być równa Cena * Ilosc.");
        }
        [TestMethod]
        public void Produkt_CenaUjemna()
        {
            // Arrange
            var produkt = PrzygotujProdukt();
            // Ustawiamy cenę na wartość ujemną
            produkt.Price *= -1;
            // Act
            bool isCenaDodatnia = produkt.Price >= 0;
            // Assert
            Assert.IsFalse(isCenaDodatnia, "Cena produktu powinna być nieujemna.");
        }
        [TestMethod]
        public void PoliczWszystkieProdukty()
        {
            // Arrange
            var produkty = PrzygotujListeProduktów();
            // Act
            int liczbaProduktow = produkty.Count;
            // Assert
            Assert.AreEqual(10000, liczbaProduktow, "Liczba produktów powinna wynosić 10000.");
        }
        [TestMethod]
        public void SprawdzCeny()
        {
            // Arrange
            var produkty = PrzygotujListeProduktów();
            // Act
            int licznik = 0;
            foreach (var produkt in produkty)
            {
                if (produkt.Price > 0)
                {
                    licznik++; // za każdy produkt z ceną większą od 0 zwiększamy licznik
                }
            }
            // Assert czy ilość produktów z ceną jest większą od zera równa całkowitej liczbie produktów
            Assert.AreEqual(produkty.Count, licznik, "Wszystkie produkty powinny mieć cenę większą od 0.");
        }

            [TestMethod]
            public void CzyOpisPodzespoluZawieraProducenta()
            {
                //arrange - przygotowujemy obiekt podzespołu
                string nazwaProducenta = "Producent1";
                var podzespol = new Podzespol
                {
                    Name = "Podzespol1",
                    Price = 25.0,
                    Category = "Kategoria2",
                    Quantity = 2,
                    Producent = nazwaProducenta
                };
                //act - sciagam opis do zmiennej
                var opis = podzespol.Opis();
                //assert - sprawdzam czy opis zawiera nazwę producenta
                StringAssert.Contains(opis, nazwaProducenta, "Opis podzespołu powinien zawierać nazwę producenta.");
            }
            //napisz testy które sprawdzą czy:
            //1. wartosc magazynu dla usługi jest poprawnie ustawiona (powinna być równa 0)
            [TestMethod]
            public void WartoscMagazynuDlaUslugi()
            {
                //arrange - przygotowujemy obiekt usługi
                var usluga = new Usluga { Name = "Usluga1", Price = 20.0, Category = "Kategoria3", Quantity = 0 };
                //act - sciagam wartosc magazynu do zmiennej
                var wartoscMagazynu = usluga.WartoscMagazynu;
                //assert - sprawdzam czy wartosc magazynu jest równa 0
                Assert.AreEqual(0, wartoscMagazynu, "Wartość magazynu dla usługi powinna być równa 0.");
            }
            //2. czy opis akcesorium zawiera kolor akcesorium
            [TestMethod]
            public void CzyOpisAkcesoriumZawieraKolor()
            {
                //arrange - przygotowujemy obiekt akcesorium
                string kolor = "Czerwony";
                var akcesorium = new Akcesorium
                {
                    Name = "Akcesorium1",
                    Price = 15.0,
                    Category = "Kategoria2",
                    Quantity = 3,
                    Kolor = kolor
                };
                //act - sciagam opis do zmiennej
                var opis = akcesorium.Opis();
                //assert - sprawdzam czy opis zawiera kolor akcesorium
                StringAssert.Contains(opis, kolor, "Opis akcesorium powinien zawierać kolor akcesorium.");
            }

        }
    }