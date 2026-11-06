namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // nazwa trasy = nazwa klasy strony
            Routing.RegisterRoute(nameof(SzczegolyPage), typeof(SzczegolyPage));
        }

    }
}
