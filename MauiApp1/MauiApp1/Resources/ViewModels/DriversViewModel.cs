using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MauiApp1.Resources.ViewModels
{
    // ViewModels/DriversViewModel.cs
    public partial class DriversViewModel : ObservableObject
    {
        private readonly LogicContext _context;

        [ObservableProperty]
        private ObservableCollection<Driver> drivers = new();

        [ObservableProperty]
        private bool isLoading;

        public DriversViewModel(LogicContext context) => _context = context;

        [RelayCommand]
        public async Task LoadAsync()
        {
            try
            {
                IsLoading = true;
                var data = await _context.Drivers
                    .Include(d => d.Transport)
                    .ToListAsync();
                Drivers = new ObservableCollection<Driver>(data);
            }
            finally { IsLoading = false; }
        }
    }
}
