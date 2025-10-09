using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilApp.ViewModels.Admin
{
    partial class AdminCapacitacionesViewModel : ObservableObject
    {
        GenericService<Capacitacion> capacitacionService = new();

        [ObservableProperty]
        private ObservableCollection<Capacitacion> capacitaciones;

        [ObservableProperty]
        private Capacitacion capacitacionCurrent;

        [ObservableProperty]
        private bool isRefreshing;

        [ObservableProperty]
        private string filterText;

        public IRelayCommand AddCommand { get; }
        public IRelayCommand EditCommand { get; }
        public IRelayCommand DeleteCommand { get; }
        public IRelayCommand RefreshCommand { get; }   

        public AdminCapacitacionesViewModel()
        {
            _=LoadCapacitaciones();
            AddCommand = new AsyncRelayCommand(AddCapacitacion);
            EditCommand = new AsyncRelayCommand(EditCapacitacion, CanEditOrDelete);
            DeleteCommand = new AsyncRelayCommand(DeleteCapacitacion, CanEditOrDelete);
            RefreshCommand = new AsyncRelayCommand(LoadCapacitaciones);
        }

        private async Task DeleteCapacitacion()
        {
            throw new NotImplementedException();
        }

        private bool CanEditOrDelete()
        {
            return capacitacionCurrent != null;
        }

        private async Task EditCapacitacion()
        {
            throw new NotImplementedException();
        }

        private async Task AddCapacitacion()
        {
            throw new NotImplementedException();
        }

        private async Task LoadCapacitaciones()
        {
            IsRefreshing = true;
            var capacitaciones = await capacitacionService.GetAllAsync();
            Capacitaciones = capacitaciones!=null ? new ObservableCollection<Capacitacion>(capacitaciones) : new ObservableCollection<Capacitacion>();
            IsRefreshing = false;
        }
    }
}
