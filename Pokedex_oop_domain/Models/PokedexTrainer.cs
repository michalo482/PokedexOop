﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_oop_domain.Models
{
    public class PokedexTrainer
    {
        public Guid Id { get; }
        public string NickName { get; }
        public string FullName { get; }
        public int Age { get; }
        public int RegionId { get; }
        public List<int> PokemonIds { get; }
        public DateTime DateOfJoining { get; }


        public PokedexTrainer(Guid id, string nickName, string fullName, int age, int regionId, List<int> pokemonIds, DateTime dateOfJoining)
        {
            Id = id;
            NickName = nickName;
            FullName = fullName;
            Age = age;
            RegionId = regionId;
            PokemonIds = pokemonIds;
            DateOfJoining = dateOfJoining;
        }
    }
}
