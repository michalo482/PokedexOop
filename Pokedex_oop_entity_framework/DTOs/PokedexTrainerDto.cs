using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_entity_framework.DTOs
{
    public class PokedexTrainerDto
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int RegionId { get; set; }
        public List<int> PokemonIds { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
