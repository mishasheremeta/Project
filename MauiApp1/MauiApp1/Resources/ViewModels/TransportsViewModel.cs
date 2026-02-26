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
    // ViewModels/TransportsViewModel.cs
    public partial class TransportsViewModel : ObservableObject
    {
        private readonly LogicContext _context;

        [ObservableProperty]
        private ObservableCollection<Transport> transports = new();

        [ObservableProperty]
        private bool isLoading;

        public TransportsViewModel(LogicContext context) => _context = context;

        [RelayCommand]
        public async Task LoadAsync()
        {
            try
            {
                IsLoading = true;
                var data = await _context.Transports.ToListAsync();
                Transports = new ObservableCollection<Transport>(data);
            }
            finally { IsLoading = false; }
        }
    }
}
