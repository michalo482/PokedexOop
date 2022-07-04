using Pokedex_oop_views.Commands;
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
    public class PokedexListingItemViewModel : ViewModelBase
    {
        private ModalNavigationStore modalNavigationStore;
        private PokedexTrainerStore pokedexTrainerStore;

        public PokedexTrainer PokedexTrainer { get; private set; }

        public string NickName => PokedexTrainer.NickName;

        public ICommand? EditCommand { get; }
        public ICommand? RemoveCommand { get; }

        

        public PokedexListingItemViewModel(PokedexTrainer pokedexTrainer, ModalNavigationStore modalNavigationStore, PokedexTrainerStore pokedexTrainerStore)
        {
            PokedexTrainer = pokedexTrainer;

            EditCommand = new OpenEditTrainerCommand(this, pokedexTrainerStore, modalNavigationStore);
        }

        public void Update(PokedexTrainer pokedexTrainer)
        {
            PokedexTrainer = pokedexTrainer;

            OnPropertyChanged(nameof(NickName));
        }
    }
}
