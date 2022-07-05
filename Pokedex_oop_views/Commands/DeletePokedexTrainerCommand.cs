using Pokedex_oop_domain.Models;
using Pokedex_oop_views.Stores;
using Pokedex_oop_views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_views.Commands
{
    public class DeletePokedexTrainerCommand : AsyncCommandBase
    {

        private readonly PokedexListingItemViewModel _pokedexListingItemViewModel;
        private readonly PokedexTrainerStore _pokedexTrainerStore;


        public DeletePokedexTrainerCommand(PokedexListingItemViewModel pokedexListingItemViewModel, PokedexTrainerStore pokedexTrainerStore)
        {
            _pokedexListingItemViewModel = pokedexListingItemViewModel;
            _pokedexTrainerStore = pokedexTrainerStore;
            

        }
    
        public override async Task ExecuteAsync(object parameter)
        {
            PokedexTrainer pokedexTrainer = _pokedexListingItemViewModel.PokedexTrainer;

            try
            {
                await _pokedexTrainerStore.Delete(pokedexTrainer.Id);
            }
            catch (Exception)
            {
                throw;
            }

            
        }
    }
}
