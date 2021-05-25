using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameFinder.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public int ReleaseDate { get; set; }
        public int PlayerCount { get; set; }

        public Guid _userId { get; set; }
        public Guid OwnerId { get; set; }
  
        public int GameSystemId { get; set; }
        
        public int GameGenreId { get; set; }
        public string ESRBRating { get; set; }
        public bool IsReccommended { get; set; }
        public double GamePrice { get; set; }
        public string GameGenre { get; set; }
        public string GameSystem { get; set; }
    }
}
