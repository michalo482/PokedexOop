using Pokedex_oop_domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_views.Stores
{
    public class SelectedPokedexTrainerStore
    {
        private readonly PokedexTrainerStore _pokedexTrainerStore;

        private PokedexTrainer _selectedPokedexTrainer;

        public SelectedPokedexTrainerStore(PokedexTrainerStore pokedexTrainerStore)
        {
            _pokedexTrainerStore = pokedexTrainerStore;

            _pokedexTrainerStore.PokedexTrainerUpdated += PokedexTrainerStore_PokedexTrainerUpdated;
            _pokedexTrainerStore.PokedexTrainerDeleted += PokedexTrainerStore_PokedexTrainerDeleted;
        }

        private void PokedexTrainerStore_PokedexTrainerDeleted(Guid obj)
        {
            _selectedPokedexTrainer = null;
        }

        private void PokedexTrainerStore_PokedexTrainerUpdated(PokedexTrainer obj)
        {
            if(obj.Id == SelectedPokedexTrainer?.Id)
            {
                SelectedPokedexTrainer = obj;
            }
        }

        public PokedexTrainer SelectedPokedexTrainer
        {
            get
            {
                return _selectedPokedexTrainer;
            }
            set
            {
                _selectedPokedexTrainer = value;
                SelectedPokedexTrainerChanged?.Invoke();
            }
        }

        public event Action SelectedPokedexTrainerChanged;
    }
}
