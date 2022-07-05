using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_entity_framework
{
    public class PokedexTrainerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<PokedexTrainerDbContext>
    {
        public PokedexTrainerDbContext CreateDbContext(string[] args = null)
        {

            return new PokedexTrainerDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=Pokedex.db").Options);
        }
    }
}
