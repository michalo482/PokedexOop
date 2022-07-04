using Pokedex_oop_views.Commands;
using Pokedex_oop_domain.Models;
using Pokedex_oop_views.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pokedex_oop_views.ViewModels
{
    public class EditPokedexTrainerViewModel : ViewModelBase
    {
        public Guid PokedexTrainerId { get; }

        public PokedexTrainerDetailsFormViewModel PokedexTrainerDetailsFormViewModel { get; }


        public EditPokedexTrainerViewModel(PokedexTrainer pokedexTrainer, PokedexTrainerStore pokedexTrainerStore, ModalNavigationStore modalNavigationStore)
        {

            PokedexTrainerId = pokedexTrainer.Id;
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            ICommand submitCommand = new EditTrainerCommand(this, pokedexTrainerStore, modalNavigationStore);
            PokedexTrainerDetailsFormViewModel = new PokedexTrainerDetailsFormViewModel(submitCommand, cancelCommand)
            {
                NickName = pokedexTrainer.NickName,
                FullName = pokedexTrainer.FullName,
                Age = pokedexTrainer.Age,
                RegionId = pokedexTrainer.RegionId,
                DateOfJoining = pokedexTrainer.DateOfJoining
                
            };
        }
    }
}
