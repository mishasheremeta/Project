using MauiApp1.Resources.ViewModels;

namespace MauiApp1
{
    public partial class TransportsPage : ContentPage
    {
        public TransportsPage(TransportsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ((TransportsViewModel)BindingContext).LoadAsync();
        }
    }
}