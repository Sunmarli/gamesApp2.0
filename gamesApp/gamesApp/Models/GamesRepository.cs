using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace gamesApp.Models
{
    public class GamesRepository
    {
        SQLiteConnection database;

        public GamesRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Game>();
        }

        public IEnumerable<Game> GetItems() 
        {
            return database.Table<Game>().ToList();
        }

        public Game GetItem (int id)
        {
            return database.Get<Game>(id);
        }

        public int Delete (int id)
        {
            return database.Delete<Game>(id);
        }

        public int SaveItem (Game item) 
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
