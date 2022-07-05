using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_entity_framework.DTOs
{
    public class PokedexPokemonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Weigth { get; set; }
        public int PokedexPokemonElementTypeId { get; set; }
        public int RegionId { get; set; }
        public int TrainerId { get; set; }
    }
}
