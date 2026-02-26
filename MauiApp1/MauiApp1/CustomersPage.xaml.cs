using MauiApp1.Resources.ViewModels;

namespace MauiApp1
{
    public partial class CustomersPage : ContentPage
    {
        public CustomersPage(CustomersViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ((CustomersViewModel)BindingContext).LoadAsync();
        }
    }
}