
using gamesApp.Models;
using gamesApp.Views;
using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gamesApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Games.db";
        public static GamesRepository database;
        public static GamesRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new GamesRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DBListPage());
        }

        protected override void OnStart()
        {
            if (Database.GetItems().Count() == 0)
            {
                var game1 = new Game { ImageUrl= "https://upload.wikimedia.org/wikipedia/en/f/f1/Stray_cover_art.jpg", Title = "Stray ", Description = "Stray is a 2022 adventure game developed by BlueTwelve Studio and published by Annapurna Interactive. The story follows a stray cat who falls into a walled city populated by robots, machines, and mutant bacteria, and sets out to return to the surface with the help of a drone companion, B-12.", /* Other properties */ };
                var game2 = new Game { ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b9/Elden_Ring_Box_art.jpg", Title = "Elden Ring", Description = "Elden Ring is presented through a third-person perspective; players freely roam its interactive open world. The six main areas are traversed using the player character's steed Torrent as the primary mode of travel. Linear, hidden dungeons can be explored to find useful items. Players can use several types of weapons and magic spells, including non-direct engagement enabled by stealth mechanics. ", /* Other properties */ };

                Database.SaveItem(game1);
                Database.SaveItem(game2);
                // Add more sample games if needed
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
