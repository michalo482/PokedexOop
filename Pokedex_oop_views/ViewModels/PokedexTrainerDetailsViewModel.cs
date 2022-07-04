using Pokedex_oop_views.Models;
using Pokedex_oop_views.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pokedex_oop_views.ViewModels
{
    public class PokedexTrainerDetailsViewModel : ViewModelBase
    {
        private readonly SelectedPokedexTrainerStore _selectedPokedexTrainerStore;

        private PokedexTrainer SelectedPokedexTrainer => _selectedPokedexTrainerStore.SelectedPokedexTrainer;

        public bool IsSelectedPokedexTrainer => SelectedPokedexTrainer != null;

        public string NickName => SelectedPokedexTrainer?.NickName ?? "Nieznany";
        public string FullName => SelectedPokedexTrainer?.FullName ?? "Brak danych";
        public int Age => SelectedPokedexTrainer?.Age ?? 0;
        public string Region => SelectedPokedexTrainer?.Region ?? "Default";
        public DateTime DateOfJoining => SelectedPokedexTrainer?.DateOfJoining ?? DateTime.Now;

        public ICommand? AddPokemonCommand { get; }

        public PokedexTrainerDetailsViewModel(SelectedPokedexTrainerStore selectedPokedexTrainerStore)
        {
            _selectedPokedexTrainerStore = selectedPokedexTrainerStore;

            _selectedPokedexTrainerStore.SelectedPokedexTrainerChanged += SelectedPokedexTrainerStore_SelectedPokedexTrainerChanged;
        }

        protected override void Dispose()
        {
            _selectedPokedexTrainerStore.SelectedPokedexTrainerChanged -= SelectedPokedexTrainerStore_SelectedPokedexTrainerChanged;
            
            base.Dispose();
        }

        private void SelectedPokedexTrainerStore_SelectedPokedexTrainerChanged()
        {
            OnPropertyChanged(nameof(IsSelectedPokedexTrainer));
            OnPropertyChanged(nameof(NickName));
            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(Region));
            OnPropertyChanged(nameof(DateOfJoining));
        }
    }
}
