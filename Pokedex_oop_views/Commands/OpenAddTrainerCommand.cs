using Pokedex_oop_views.Stores;
using Pokedex_oop_views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pokedex_oop_views.Commands
{
    public class OpenAddTrainerCommand : CommandBase
    {
        private readonly PokedexTrainerStore _pokedexTrainerStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddTrainerCommand(PokedexTrainerStore pokedexTrainerStore, ModalNavigationStore modalNavigationStore)
        {
            _pokedexTrainerStore = pokedexTrainerStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddPokedexTrainerViewModel viewModel = new AddPokedexTrainerViewModel(_pokedexTrainerStore, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = viewModel;
        }
    }
}
