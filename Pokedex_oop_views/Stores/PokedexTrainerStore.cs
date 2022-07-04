using Pokedex_oop_domain.Commands;
using Pokedex_oop_domain.Models;
using Pokedex_oop_domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_views.Stores
{
    public class PokedexTrainerStore
    {
        private readonly IGetAllPokkedexTrainersQuery _getAllPokedexTrainerCommand;
        private readonly ICreatePokedexTrainerCommand _createPokedexTrainerCommand;
        private readonly IUpdatePokedexTrainerCommand _updatePokedexTrainerCommand;
        private readonly IDeletePokedexTrainerCommand _deletePokedexTrainerCommand;

        public PokedexTrainerStore(IGetAllPokkedexTrainersQuery getAllPokedexTrainerCommand,
            ICreatePokedexTrainerCommand createPokedexTrainerCommand,
            IUpdatePokedexTrainerCommand updatePokedexTrainerCommand,
            IDeletePokedexTrainerCommand deletePokedexTrainerCommand)
        {
            _getAllPokedexTrainerCommand = getAllPokedexTrainerCommand;
            _createPokedexTrainerCommand = createPokedexTrainerCommand;
            _updatePokedexTrainerCommand = updatePokedexTrainerCommand;
            _deletePokedexTrainerCommand = deletePokedexTrainerCommand;
        }

        public event Action<PokedexTrainer>? PokedexTrainerAdded;
        public event Action<PokedexTrainer>? PokedexTrainerUpdated;

        public async Task Create(PokedexTrainer pokedexTrainer)
        {

            await _createPokedexTrainerCommand.Execute(pokedexTrainer);
            PokedexTrainerAdded.Invoke(pokedexTrainer);
        }

        public async Task Update(PokedexTrainer pokedexTrainer)
        {
            await _updatePokedexTrainerCommand.Execute(pokedexTrainer);

            PokedexTrainerUpdated.Invoke(pokedexTrainer);
        }
    }
}
