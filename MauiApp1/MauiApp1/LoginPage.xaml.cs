using MauiApp1.Resources.ViewModels;

namespace MauiApp1
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
