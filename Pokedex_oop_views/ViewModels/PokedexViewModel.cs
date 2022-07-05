using Pokedex_oop_views.Commands;
using Pokedex_oop_views.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pokedex_oop_views.ViewModels
{
    public class PokedexViewModel : ViewModelBase
    {
        public PokedexTrainerListingViewModel PokedexTrainerListingViewModel { get; }
        public PokedexTrainerDetailsViewModel PokedexTrainerDetailsViewModel { get; }
        public PokedexPokemonListingViewModel PokedexPokemonListingViewModel { get; }

        public ICommand? AddTrainerCommand { get; }

        public PokedexViewModel(PokedexTrainerStore pokedexTrainerStore, SelectedPokedexTrainerStore selectedPokedexTrainerStore, ModalNavigationStore modalNavigationStore)
        {
            PokedexTrainerListingViewModel = PokedexTrainerListingViewModel.LoadViewModel(pokedexTrainerStore, selectedPokedexTrainerStore, modalNavigationStore);
            PokedexTrainerDetailsViewModel = new PokedexTrainerDetailsViewModel(selectedPokedexTrainerStore);
            PokedexPokemonListingViewModel = new PokedexPokemonListingViewModel();

            AddTrainerCommand = new OpenAddTrainerCommand(pokedexTrainerStore, modalNavigationStore);
        }
    }
}
