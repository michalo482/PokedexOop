using Pokedex_oop_views.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_views.Commands
{
    public class CloseModalCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public CloseModalCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            _modalNavigationStore.CloseModal();
        }
    }
}
