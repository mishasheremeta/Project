using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.Resources.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string login = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [ObservableProperty]
        private bool hasError;

        // Захардкоджені дані — або перевіряй через БД
        private const string ValidLogin = "admin";
        private const string ValidPassword = "1111";

        [RelayCommand]
        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Введіть логін та пароль";
                HasError = true;
                return;
            }

            if (Login == ValidLogin && Password == ValidPassword)
            {
                HasError = false;
                // Переходимо до головного Shell
                Application.Current!.MainPage = new AppShell();
            }
            else
            {
                ErrorMessage = "Невірний логін або пароль";
                HasError = true;
            }
        }
    }
}