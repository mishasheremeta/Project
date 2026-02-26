using MauiApp1.Resources.ViewModels;

namespace MauiApp1
{
    public partial class AddCargoPage : ContentPage
    {
        public AddCargoPage(AddCargoViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ((AddCargoViewModel)BindingContext).LoadCustomersAsync();
        }
    }
}
