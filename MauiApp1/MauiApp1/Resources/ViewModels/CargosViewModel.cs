using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using logic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace MauiApp1.Resources.ViewModels
{
    public partial class CargosViewModel : ObservableObject
    {
        private readonly LogicContext _context;

        [ObservableProperty]
        private ObservableCollection<Cargo> cargos = new();

        [ObservableProperty]
        private bool isLoading;

        public CargosViewModel(LogicContext context) => _context = context;

        [RelayCommand]
        public async Task LoadAsync()
        {
            try
            {
                IsLoading = true;
                var data = await _context.Cargos
                    .Include(c => c.Customer)
                    .ToListAsync();
                Cargos = new ObservableCollection<Cargo>(data);
            }
            finally { IsLoading = false; }
        }

        [RelayCommand]
        private async Task AddCargoAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddCargoPage));
        }
    }
}
