using Pokedex_oop_domain.Commands;
using Pokedex_oop_entity_framework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_entity_framework.Commands
{
    public class DeletePokedexTrainerCommand : IDeletePokedexTrainerCommand
    {
        private readonly PokedexTrainerDbContextFactory _contextFactory;

        public DeletePokedexTrainerCommand(PokedexTrainerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        
        public async Task Execute(Guid id)
        {
            using (PokedexTrainerDbContext context = _contextFactory.Create())
            {
                PokedexTrainerDto pokedexTrainerDto = new PokedexTrainerDto()
                {
                    Id = id,                   
                };
                context.PokedexTrainers.Remove(pokedexTrainerDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
