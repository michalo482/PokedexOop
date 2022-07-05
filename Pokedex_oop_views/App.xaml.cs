using Pokedex_oop_views.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Pokedex_oop_views.Stores;
using Pokedex_oop_domain.Queries;
using Pokedex_oop_domain.Commands;
using Pokedex_oop_entity_framework.Queries;
using Pokedex_oop_entity_framework.Commands;
using Pokedex_oop_entity_framework;
using Microsoft.EntityFrameworkCore;

namespace Pokedex_oop_views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly PokedexTrainerDbContextFactory _pokedexTrainerDbContextFactory;
        private readonly IGetAllPokkedexTrainersQuery _getAllPokedexTrainerCommand;
        private readonly ICreatePokedexTrainerCommand _createPokedexTrainerCommand;
        private readonly IUpdatePokedexTrainerCommand _updatePokedexTrainerCommand;
        private readonly IDeletePokedexTrainerCommand _deletePokedexTrainerCommand;
        private readonly SelectedPokedexTrainerStore _selectedPokedexTrainer;
        private readonly PokedexTrainerStore _pokedexTrainerStore;

        public App()
        {

            string connectionString = "Data Source=Pokedex.db";
            _modalNavigationStore = new ModalNavigationStore();
            _pokedexTrainerDbContextFactory = new PokedexTrainerDbContextFactory(
                new DbContextOptionsBuilder().UseSqlite(connectionString).Options 
                );
            _getAllPokedexTrainerCommand = new GetAllPokedexTrainersQuery(_pokedexTrainerDbContextFactory);
            _createPokedexTrainerCommand = new CreatePokedexTrainerCommand(_pokedexTrainerDbContextFactory);
            _updatePokedexTrainerCommand = new UpdatePokedexTrainerCommand(_pokedexTrainerDbContextFactory);
            _deletePokedexTrainerCommand = new DeletePokedexTrainerCommand(_pokedexTrainerDbContextFactory);
            _pokedexTrainerStore = new PokedexTrainerStore(_getAllPokedexTrainerCommand, _createPokedexTrainerCommand, _updatePokedexTrainerCommand, _deletePokedexTrainerCommand);
            _selectedPokedexTrainer = new SelectedPokedexTrainerStore(_pokedexTrainerStore);
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            using (PokedexTrainerDbContext context = _pokedexTrainerDbContextFactory.Create())
            {
                context.Database.Migrate();
            }
                MainWindow = new MainWindow()
                {
                    DataContext = new MainViewModel(_modalNavigationStore, new PokedexViewModel(_pokedexTrainerStore, _selectedPokedexTrainer, _modalNavigationStore))
                };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
