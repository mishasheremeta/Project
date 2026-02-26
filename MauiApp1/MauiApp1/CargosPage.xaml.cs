using MauiApp1.Resources.ViewModels;

namespace MauiApp1;

public partial class CargosPage : ContentPage
{
    public CargosPage(CargosViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ((CargosViewModel)BindingContext).LoadAsync();
    }
}