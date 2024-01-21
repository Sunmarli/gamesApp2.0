using gamesApp.Views;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace gamesApp.VeiwModels
{
    public class GamesListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GameViewModel> Games { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateGameCommand { get; set; }
        public ICommand DeleteGameCommand { get; set; }
        public ICommand SaveGameCommand { get; set; }
        public ICommand BackCommand { get; set; }

        GameViewModel selectedGame;
        public INavigation Navigation { get; set; }

        public GamesListViewModel()
        {
            Games = new ObservableCollection<GameViewModel>();
            CreateGameCommand = new Command(CreateGame);
            DeleteGameCommand = new Command(DeleteGame);
            SaveGameCommand = new Command(SaveGame);
            BackCommand = new Command(Back);
        } 

        public GameViewModel SelectedGame
        {
            get { return selectedGame; }
            set
            {
                if (selectedGame != value)
                {
                    GameViewModel tempGame = value;
                    selectedGame = null;
                    OnPropertyChanged("SelectedGame");
                    Navigation.PushAsync(new GamePage(tempGame));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateGame()
        {
            Navigation.PushAsync(new GamePage(new GameViewModel() { ListViewModel = this}));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void SaveGame(object GameObject)
        {
            GameViewModel Game = GameObject as GameViewModel;
            if (Game != null && Game.IsValid && !Games.Contains(Game))
            {
                Games.Add(Game);
            }
            Back();
        }

        private void DeleteGame(object GameObject)
        {
            GameViewModel Game = GameObject as GameViewModel;
            if (Game != null)
            {
                Games.Remove(Game);
            }
            Back();
        }
    }
}
