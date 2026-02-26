namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Реєстрація маршруту для сторінки додавання
            Routing.RegisterRoute(nameof(AddCargoPage), typeof(AddCargoPage));
        }
    }
}
