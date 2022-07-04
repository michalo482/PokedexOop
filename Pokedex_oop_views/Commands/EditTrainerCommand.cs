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
    public class EditTrainerCommand : AsyncCommandBase
    {
        private readonly EditPokedexTrainerViewModel _editPokedexTrainerViewModel;
        private readonly PokedexTrainerStore _pokedexTrainerStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditTrainerCommand(EditPokedexTrainerViewModel editPokedexTrainerViewModel, PokedexTrainerStore pokedexTrainerStore, ModalNavigationStore modalNavigationStore)
        {
            _editPokedexTrainerViewModel = editPokedexTrainerViewModel;
            _pokedexTrainerStore = pokedexTrainerStore;
            _modalNavigationStore = modalNavigationStore;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            // TODO: Add code to edit trainer in database

            PokedexTrainerDetailsFormViewModel formViewModel = _editPokedexTrainerViewModel.PokedexTrainerDetailsFormViewModel;

            PokedexTrainer pokedexTrainer = new PokedexTrainer(_editPokedexTrainerViewModel.PokedexTrainerId, formViewModel.NickName, formViewModel.FullName, formViewModel.Age, formViewModel.RegionId, formViewModel.DateOfJoining);

            try
            {
                await _pokedexTrainerStore.Update(pokedexTrainer);
                _modalNavigationStore.CloseModal();
            }
            catch (Exception) { }
        }

      
    }
}
