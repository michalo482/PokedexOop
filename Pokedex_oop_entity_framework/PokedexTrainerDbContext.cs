using Microsoft.EntityFrameworkCore;
using Pokedex_oop_entity_framework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_entity_framework
{
    public class PokedexTrainerDbContext : DbContext
    {
        public PokedexTrainerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PokedexTrainerDto> PokedexTrainers { get; set; }
    }
}
