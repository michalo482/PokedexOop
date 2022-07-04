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
    public class SubmitAddTrainerCommand : AsyncCommandBase
    {
        private readonly AddPokedexTrainerViewModel _addPokedexTrainerViewModel;
        private readonly PokedexTrainerStore _pokedexTrainerStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public SubmitAddTrainerCommand(AddPokedexTrainerViewModel addPokedexTrainerViewModel, PokedexTrainerStore pokedexTrainerStore, ModalNavigationStore modalNavigationStore)
        {
            _addPokedexTrainerViewModel = addPokedexTrainerViewModel;
            _pokedexTrainerStore = pokedexTrainerStore;
            _modalNavigationStore = modalNavigationStore;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            // TODO: Add code to add trainer to database

            PokedexTrainerDetailsFormViewModel formViewModel = _addPokedexTrainerViewModel.PokedexTrainerDetailsFormViewModel;

            PokedexTrainer pokedexTrainer = new PokedexTrainer(Guid.NewGuid(), formViewModel.NickName, formViewModel.FullName, formViewModel.Age, formViewModel.Region, formViewModel.DateOfJoining);

            try
            {
                await _pokedexTrainerStore.Create(pokedexTrainer);
                _modalNavigationStore.CloseModal();
            }
            catch (Exception) { }
            
                

            
        }
    }
}
