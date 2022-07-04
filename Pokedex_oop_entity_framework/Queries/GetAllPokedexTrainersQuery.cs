using Microsoft.EntityFrameworkCore;
using Pokedex_oop_domain.Models;
using Pokedex_oop_domain.Queries;
using Pokedex_oop_entity_framework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_entity_framework.Queries
{
    public class GetAllPokedexTrainersQuery : IGetAllPokkedexTrainersQuery
    {
        private readonly PokedexTrainerDbContextFactory _contextFactory;

        public GetAllPokedexTrainersQuery(PokedexTrainerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<PokedexTrainer>> Execute()
        {
            using (PokedexTrainerDbContext context = _contextFactory.Create())
            {
                IEnumerable<PokedexTrainerDto> pokedexTrainerDtos = await context.PokedexTrainers.ToListAsync();

                return pokedexTrainerDtos.Select(y => new PokedexTrainer(y.Id, y.NickName, y.FullName, y.Age, y.RegionId, y.PokemonIds, y.DateOfJoining));
            }
        }
    }
}
