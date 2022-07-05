using Pokedex_oop_views.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_views.Commands
{
    public class LoadPokedexTrainersCommand : AsyncCommandBase
    {

        private readonly PokedexTrainerStore _pokedexTrainerStore;

        public LoadPokedexTrainersCommand(PokedexTrainerStore pokedexTrainerStore)
        {
            _pokedexTrainerStore = pokedexTrainerStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {

            try
            {
                await _pokedexTrainerStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
