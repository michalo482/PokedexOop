using Pokedex_oop_views.Models;
using Pokedex_oop_views.Stores;
using Pokedex_oop_views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_views.Commands
{
    public class OpenEditTrainerCommand : CommandBase
    {
        
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly PokedexListingItemViewModel _pokedexListingItemViewModel;
        private readonly PokedexTrainerStore _pokedexTrainerStore;
        

        public OpenEditTrainerCommand(PokedexListingItemViewModel pokedexListingItemViewModel, PokedexTrainerStore pokedexTrainerStore, ModalNavigationStore modalNavigationStore)
        {
            _pokedexListingItemViewModel = pokedexListingItemViewModel;
            _pokedexTrainerStore = pokedexTrainerStore;
            _modalNavigationStore = modalNavigationStore;

        }

        public override void Execute(object? parameter)
        {
            PokedexTrainer pokedexTrainer = _pokedexListingItemViewModel.PokedexTrainer;

            EditPokedexTrainerViewModel viewModel = new EditPokedexTrainerViewModel(pokedexTrainer, _pokedexTrainerStore, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = viewModel;
        }
    }
}
