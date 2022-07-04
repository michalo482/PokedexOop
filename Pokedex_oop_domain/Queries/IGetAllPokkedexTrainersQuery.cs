using Pokedex_oop_domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_domain.Queries
{
    public interface IGetAllPokkedexTrainersQuery
    {
        Task<IEnumerable<PokedexTrainer>> Execute();
    }
}
