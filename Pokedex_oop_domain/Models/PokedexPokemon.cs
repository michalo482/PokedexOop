using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_domain.Models
{
    public class PokedexPokemon
    {
        public Guid Id { get; }
        public string Name { get; }
        public double Weigth { get; }
        public int PokedexPokemonElementTypeId { get; }
        public int RegionId { get; }
        public int TrainerId { get; }
    }
}
