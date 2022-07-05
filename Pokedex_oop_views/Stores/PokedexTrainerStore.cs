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

        private readonly List<PokedexTrainer> _pokedexTrainers;

        public IEnumerable<PokedexTrainer> PokedexTrainers => _pokedexTrainers;

        public event Action PokedexTrainerLoaded;

        public PokedexTrainerStore(IGetAllPokkedexTrainersQuery getAllPokedexTrainerCommand,
            ICreatePokedexTrainerCommand createPokedexTrainerCommand,
            IUpdatePokedexTrainerCommand updatePokedexTrainerCommand,
            IDeletePokedexTrainerCommand deletePokedexTrainerCommand)
        {
            _getAllPokedexTrainerCommand = getAllPokedexTrainerCommand;
            _createPokedexTrainerCommand = createPokedexTrainerCommand;
            _updatePokedexTrainerCommand = updatePokedexTrainerCommand;
            _deletePokedexTrainerCommand = deletePokedexTrainerCommand;

            _pokedexTrainers = new List<PokedexTrainer>();
        }

        public event Action<PokedexTrainer>? PokedexTrainerAdded;
        public event Action<PokedexTrainer>? PokedexTrainerUpdated;
        public event Action<Guid>? PokedexTrainerDeleted;


        public async Task Load()
        {
            IEnumerable<PokedexTrainer>? pokedexTrainers = await _getAllPokedexTrainerCommand.Execute();

            _pokedexTrainers.Clear();
            _pokedexTrainers.AddRange(pokedexTrainers);

            PokedexTrainerLoaded.Invoke();
        }

        public async Task Create(PokedexTrainer pokedexTrainer)
        {

            await _createPokedexTrainerCommand.Execute(pokedexTrainer);

            _pokedexTrainers.Add(pokedexTrainer);
            
            PokedexTrainerAdded.Invoke(pokedexTrainer);
        }

        public async Task Update(PokedexTrainer pokedexTrainer)
        {
            await _updatePokedexTrainerCommand.Execute(pokedexTrainer);

            int currentIndex =  _pokedexTrainers.FindIndex(y => y.Id == pokedexTrainer.Id);

            if(currentIndex != -1)
            {
                _pokedexTrainers[currentIndex] = pokedexTrainer;
            }
            else
            {
                _pokedexTrainers.Add(pokedexTrainer);
            }

            PokedexTrainerUpdated.Invoke(pokedexTrainer);
        }

        public async Task Delete(Guid id)
        {
            await _deletePokedexTrainerCommand.Execute(id);

            _pokedexTrainers.RemoveAll(x => x.Id == id);

            PokedexTrainerDeleted?.Invoke(id);
        }
    }
}
