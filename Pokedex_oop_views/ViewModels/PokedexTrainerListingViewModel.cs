using Pokedex_oop_views.Commands;
using Pokedex_oop_domain.Models;
using Pokedex_oop_views.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pokedex_oop_views.ViewModels
{
    public class PokedexTrainerListingViewModel : ViewModelBase
    {

        private readonly ObservableCollection<PokedexListingItemViewModel> _pokedexTrainerListing;
        private readonly PokedexTrainerStore _pokedexTrainerStore;
        private readonly SelectedPokedexTrainerStore _selectedPokedexTrainerStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public IEnumerable<PokedexListingItemViewModel> PokedexTrainerListing => _pokedexTrainerListing;

        private PokedexListingItemViewModel _selectedPokedexTrainerListingItemViewModel;

        public DateTime date = DateTime.Now;
        
        public PokedexListingItemViewModel SelectedPokedexTrainerListingItemViewModel
        {
            get
            {
                return _selectedPokedexTrainerListingItemViewModel;
            }
            set
            {
                _selectedPokedexTrainerListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedPokedexTrainerListingItemViewModel));
                _selectedPokedexTrainerStore.SelectedPokedexTrainer = _selectedPokedexTrainerListingItemViewModel?.PokedexTrainer;
            }
        }
              
        public PokedexTrainerListingViewModel(PokedexTrainerStore pokedexTrainerStore, SelectedPokedexTrainerStore selectedPokedexTrainerStore, ModalNavigationStore modalNavigationStore)
        {
            _pokedexTrainerStore = pokedexTrainerStore;
            _selectedPokedexTrainerStore = selectedPokedexTrainerStore;
            _modalNavigationStore = modalNavigationStore;
            _pokedexTrainerListing = new ObservableCollection<PokedexListingItemViewModel>();

            _pokedexTrainerStore.PokedexTrainerAdded += PokedexTrainerStore_PokedexTrainerAdded;
            _pokedexTrainerStore.PokedexTrainerUpdated += PokedexTrainerStore_PokedexTrainerUpdated;

            /*AddPokedexTrainer(new PokedexTrainer("Ash", "Ash Keczup", 16, "Kanto", date), modalNavigationStore);
            AddPokedexTrainer(new PokedexTrainer("Misty", "Misty Keczup", 14, "Kanto", date), modalNavigationStore);
            AddPokedexTrainer(new PokedexTrainer("Brock", "Brock Keczup", 22, "Kanto", date), modalNavigationStore);*/

        }

        private void PokedexTrainerStore_PokedexTrainerUpdated(PokedexTrainer pokedexTrainer)
        {
            PokedexListingItemViewModel? pokedexTrainerViewModel = _pokedexTrainerListing.FirstOrDefault(y => y.PokedexTrainer.Id == pokedexTrainer.Id);

            if(pokedexTrainerViewModel != null)
            {
                pokedexTrainerViewModel.Update(pokedexTrainer);
            }
        }

        protected override void Dispose()
        {
            _pokedexTrainerStore.PokedexTrainerAdded -= PokedexTrainerStore_PokedexTrainerAdded;
            _pokedexTrainerStore.PokedexTrainerUpdated -= PokedexTrainerStore_PokedexTrainerUpdated;
            base.Dispose();
        }

        private void PokedexTrainerStore_PokedexTrainerAdded(PokedexTrainer obj)
        {
            AddPokedexTrainer(obj);
        }

        private void AddPokedexTrainer(PokedexTrainer pokedexTrainer)
        {
            
            _pokedexTrainerListing.Add(new PokedexListingItemViewModel(pokedexTrainer, _modalNavigationStore, _pokedexTrainerStore));
        }
    }  
}
