using Pokedex_oop_domain.Commands;
using Pokedex_oop_domain.Models;
using Pokedex_oop_entity_framework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_entity_framework.Commands
{
    public class UpdatePokedexTrainerCommand : IUpdatePokedexTrainerCommand 
    {
        private readonly PokedexTrainerDbContextFactory _contextFactory;

        public UpdatePokedexTrainerCommand(PokedexTrainerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(PokedexTrainer pokedexTrainer)
        {
            using(PokedexTrainerDbContext context = _contextFactory.Create())
            {
                PokedexTrainerDto pokedexTrainerDto = new PokedexTrainerDto()
                {
                    Id = pokedexTrainer.Id,
                    NickName = pokedexTrainer.NickName,
                    FullName = pokedexTrainer.FullName,
                    Age = pokedexTrainer.Age,
                    RegionId = pokedexTrainer.RegionId,
                    PokemonId = (int)pokedexTrainer.PokemonId,
                    DateOfJoining = pokedexTrainer.DateOfJoining
                };
                context.PokedexTrainers.Update(pokedexTrainerDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
