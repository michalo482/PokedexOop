using Pokedex_oop_views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_views.Stores
{
    public class PokedexTrainerStore
    {
        public event Action<PokedexTrainer>? PokedexTrainerAdded;
        public event Action<PokedexTrainer>? PokedexTrainerUpdated;

        public async Task Create(PokedexTrainer pokedexTrainer)
        {
            PokedexTrainerAdded.Invoke(pokedexTrainer);
        }

        public async Task Update(PokedexTrainer pokedexTrainer)
        {
            PokedexTrainerUpdated.Invoke(pokedexTrainer);
        }
    }
}
