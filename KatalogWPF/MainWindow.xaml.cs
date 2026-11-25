using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KatalogProduktow;

namespace KatalogWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var produkty = new List<Produkt>
            {
                new Podzespol { Nazwa = "Procesor", Cena = 250.00, Kategoria = "Elektronika", Ilosc = 10 },
                new Akcesorium { Nazwa = "Myszka", Cena = 50.00, Kategoria = "Elektronika", Ilosc = 15 },
                new Usluga { Nazwa = "Naprawa komputera", Cena = 150.00, Kategoria = "Usługi", Ilosc = 0 },
            };
            ProduktyListBox.ItemsSource = produkty;
            LiczbaProduktowTextBlock.Text = produkty.Count.ToString();
            WartoscProduktowTextBlock.Text = produkty.Sum(p => p.Cena * p.Ilosc).ToString("F2") + "zł";
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //uruchom drugie okno - DockPanelDemo
        //    DockPanelDemo dockPanelDemo = new DockPanelDemo();
        //    dockPanelDemo.Show();
        //}
    }
}