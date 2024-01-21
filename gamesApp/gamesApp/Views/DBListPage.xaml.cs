using gamesApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gamesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBListPage : ContentPage
    {
        public DBListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            gamesList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        
       

        //обработка нажатия кнопки добавления

        private async void CreateGame(object sender, EventArgs e)
        {
            Game game = new Game();
            DBGamePage gamePage = new DBGamePage();
            gamePage.BindingContext = game;
            await Navigation.PushAsync(gamePage);
        }
        //private async void DeleteGame(object sender, EventArgs e)
        //{
        //    var Game = (Game)BindingContext;
        //    App.Database.Delete(Game.Id);
        //    this.Navigation.PopAsync();
        //}
      
        private async void OnDetailsClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Game selectedGame)
            {
                await HandleItemSelected(selectedGame);
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Game selectedGame)
            {
                await HandleItemSelected(selectedGame);
            }
        }

        private async Task HandleItemSelected(Game selectedGame)
        {
            DBGamePage gamePage = new DBGamePage();
            gamePage.BindingContext = selectedGame;
            await Navigation.PushAsync(gamePage);
            await DisplayAlert("Operation", $"Performing operation for game: {selectedGame.Title}", "OK");
        }





    }
}