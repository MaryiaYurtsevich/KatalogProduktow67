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
                new Podzespol { Name = "Procesor", Price = 250.00, Category = "Elektronika", Quantity = 10 },
                new Akcesorium { Name = "Myszka", Price = 50.00, Category = "Elektronika", Quantity = 15 },
                new Usluga { Name = "Naprawa komputera", Price = 150.00, Category = "Usługi", Quantity = 0 },
            };
            ProduktyListBox.ItemsSource = produkty;
        }
    }
}