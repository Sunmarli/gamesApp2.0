
using gamesApp.Models;
using System.ComponentModel;

namespace gamesApp.VeiwModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        GamesListViewModel lvm;
        public Game Game { get; private set; }

        public GameViewModel()
        {
            Game = new Game();
        }

        public GamesListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Title
        {
            get { return Game.Title; }
            set
            {
                if (Game.Title != value)
                {
                    Game.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public string Description
        {
            get { return Game.Description; }
            set
            {
                if (Game.Description != value)
                {
                    Game.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public string ImageUrl
        {
            get { return Game.ImageUrl; }
            set
            {
                if (Game.ImageUrl != value)
                {
                    Game.ImageUrl = value;
                    OnPropertyChanged("ImageUrl");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Title.Trim()))) ||
                    (!string.IsNullOrEmpty(Description.Trim())) ||
                    (!string.IsNullOrEmpty(ImageUrl.Trim()));
            }
        }

        protected void OnPropertyChanged (string propName)
        {
            if (PropertyChanged !=null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
