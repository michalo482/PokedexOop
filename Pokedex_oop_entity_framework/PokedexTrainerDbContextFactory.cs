using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_entity_framework
{
    public class PokedexTrainerDbContextFactory
    {
        
        private readonly DbContextOptions _options;

        public PokedexTrainerDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public PokedexTrainerDbContext Create()
        {

            return new PokedexTrainerDbContext(_options);
        }
    }
}
