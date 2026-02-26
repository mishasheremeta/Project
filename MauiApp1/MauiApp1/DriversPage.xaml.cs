using MauiApp1.Resources.ViewModels;

namespace MauiApp1;

public partial class DriversPage : ContentPage
{
    public DriversPage(DriversViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ((DriversViewModel)BindingContext).LoadAsync();
    }
}