
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gamesApp.Models;
using gamesApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gamesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBGamePage : ContentPage
    {
        public DBGamePage()
        {
            InitializeComponent();
        }

        private void SaveGame(object sender, EventArgs e)
        {
            var Game = (Game)BindingContext;
            if (!String.IsNullOrEmpty(Game.Title))
            {
                App.Database.SaveItem(Game);
            }
            this.Navigation.PopAsync();
        }

        public void DeleteGame(object sender, EventArgs e)
        {
            var Game = (Game)BindingContext;
            App.Database.Delete(Game.Id);
            this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }


    }
}