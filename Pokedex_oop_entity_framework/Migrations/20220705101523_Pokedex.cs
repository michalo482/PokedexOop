using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex_oop_entity_framework.Migrations
{
    public partial class Pokedex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pokedexPokemonDtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Weigth = table.Column<double>(type: "REAL", nullable: false),
                    PokedexPokemonElementTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrainerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokedexPokemonDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pokedexPokemonElementTypeDtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ElementTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokedexPokemonElementTypeDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pokedexRegionDtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RegionName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokedexRegionDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokedexTrainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NickName = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokedexTrainers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pokedexPokemonDtos");

            migrationBuilder.DropTable(
                name: "pokedexPokemonElementTypeDtos");

            migrationBuilder.DropTable(
                name: "pokedexRegionDtos");

            migrationBuilder.DropTable(
                name: "PokedexTrainers");
        }
    }
}
