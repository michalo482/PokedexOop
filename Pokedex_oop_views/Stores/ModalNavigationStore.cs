using Pokedex_oop_views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_views.Stores
{
    public class ModalNavigationStore
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }

        internal void CloseModal()
        {
            CurrentViewModel = null;
        }

        public bool IsModalOpen => CurrentViewModel != null;

        public event Action CurrentViewModelChanged;

    }
}
