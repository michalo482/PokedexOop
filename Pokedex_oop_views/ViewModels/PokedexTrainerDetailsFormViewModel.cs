using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pokedex_oop_views.ViewModels
{
    public class PokedexTrainerDetailsFormViewModel : ViewModelBase
    {
        private string _nickName;
        
        public string NickName
        {
            get
            {
                return _nickName;
            }
            set
            {
                _nickName = value;
                OnPropertyChanged(nameof(NickName));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _fullName;

        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        private int _age;

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private int _regionId;

        public int RegionId
        {
            get
            {
                return _regionId;
            }
            set
            {
                _regionId = value;
                OnPropertyChanged(nameof(RegionId));
            }
        }

        private int _pokemonId;

        public int PokemonId
        {
            get
            {
                return _pokemonId;
            }
            set
            {
                _pokemonId = value;
                OnPropertyChanged(nameof(PokemonId));
            }
        }        

        private DateTime _dateOfJoining;

        public PokedexTrainerDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

        public DateTime DateOfJoining
        {
            get
            {
                return _dateOfJoining;
            }
            set
            {
                _dateOfJoining = value;
                OnPropertyChanged(nameof(DateOfJoining));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(NickName);
        
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        
    }
}
