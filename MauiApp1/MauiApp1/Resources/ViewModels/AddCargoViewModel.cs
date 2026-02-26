using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using logic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace MauiApp1.Resources.ViewModels
{
    public partial class AddCargoViewModel : ObservableObject
    {
        private readonly LogicContext _context;

        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private string origin = string.Empty;

        [ObservableProperty]
        private string destination = string.Empty;

        [ObservableProperty]
        private string type = string.Empty;

        [ObservableProperty]
        private string weight = string.Empty;

        [ObservableProperty]
        private int price;

        [ObservableProperty]
        private int cargoCode;

        [ObservableProperty]
        private string status = string.Empty;

        [ObservableProperty]
        private Customer? selectedCustomer;

        [ObservableProperty]
        private ObservableCollection<Customer> customers = new();

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [ObservableProperty]
        private bool hasError;

        public AddCargoViewModel(LogicContext context)
        {
            _context = context;
        }

        public async Task LoadCustomersAsync()
        {
            var data = await _context.Customers.ToListAsync();
            Customers = new ObservableCollection<Customer>(data);
        }

        [RelayCommand]
        private async Task SaveAsync()
        {
            // Валідація
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Origin) ||
                string.IsNullOrWhiteSpace(Destination) ||
                SelectedCustomer == null)
            {
                ErrorMessage = "Заповніть всі обов'язкові поля";
                HasError = true;
                return;
            }

            HasError = false;

            var cargo = new Cargo
            {
                Name = Name,
                Origin = Origin,
                Destination = Destination,
                Type = Type,
                Weight = Weight,
                Price = Price,
                CargoCode = CargoCode,
                Status = Status,
                CustomerId = SelectedCustomer.Id
            };

            await _context.Cargos.AddAsync(cargo);
            await _context.SaveChangesAsync();

            // Повертаємось назад
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
