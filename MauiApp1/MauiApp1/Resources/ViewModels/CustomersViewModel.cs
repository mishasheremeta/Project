using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using logic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace MauiApp1.Resources.ViewModels
{
    // ViewModels/CustomersViewModel.cs
    public partial class CustomersViewModel : ObservableObject
    {
        private readonly LogicContext _context;

        [ObservableProperty]
        private ObservableCollection<Customer> customers = new();

        [ObservableProperty]
        private bool isLoading;

        public CustomersViewModel(LogicContext context) => _context = context;

        [RelayCommand]
        public async Task LoadAsync()
        {
            try
            {
                IsLoading = true;
                var data = await _context.Customers.ToListAsync();
                Customers = new ObservableCollection<Customer>(data);
            }
            finally { IsLoading = false; }
        }
    }
}
