﻿using Pokedex_oop_views.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Pokedex_oop_views.Stores;

namespace Pokedex_oop_views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SelectedPokedexTrainerStore _selectedPokedexTrainer;
        private readonly PokedexTrainerStore _pokedexTrainerStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _pokedexTrainerStore = new PokedexTrainerStore();
            _selectedPokedexTrainer = new SelectedPokedexTrainerStore(_pokedexTrainerStore);
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, new PokedexViewModel(_pokedexTrainerStore, _selectedPokedexTrainer, _modalNavigationStore))
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}