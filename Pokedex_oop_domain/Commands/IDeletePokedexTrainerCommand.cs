﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_domain.Commands
{
    public interface IDeletePokedexTrainerCommand
    {
        Task Execute(Guid id);
    }
}
