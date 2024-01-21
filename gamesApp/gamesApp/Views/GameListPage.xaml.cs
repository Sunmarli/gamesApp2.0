using gamesApp.VeiwModels;
using gamesApp.Models;
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
    public partial class GameListPage : ContentPage
    {
        public GameListPage()
        {
            InitializeComponent();
            BindingContext = new GamesListViewModel() { Navigation = this.Navigation };
        }
    }
}