using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace gamesApp.Models
{
    [Table("Games")]
    public class Game
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
