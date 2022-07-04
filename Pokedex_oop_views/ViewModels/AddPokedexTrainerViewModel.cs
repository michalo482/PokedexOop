using Pokedex_oop_views.Commands;
using Pokedex_oop_views.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pokedex_oop_views.ViewModels
{
    public class AddPokedexTrainerViewModel : ViewModelBase
    {
        public PokedexTrainerDetailsFormViewModel PokedexTrainerDetailsFormViewModel { get; }


        public AddPokedexTrainerViewModel(PokedexTrainerStore pokedexTrainerStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand( modalNavigationStore);
            ICommand submitCommand = new SubmitAddTrainerCommand(this, pokedexTrainerStore, modalNavigationStore);
            PokedexTrainerDetailsFormViewModel = new PokedexTrainerDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }

    
    
}
