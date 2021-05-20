using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameFinder.Models
{
    public class GameCreate
    {
        public string GameTitle { get; set; }
        public double GamePrice { get; set; }
        public string GameSystem { get; set; }
        public string ESRBRating { get; set; }
        public bool IsReccommended { get; set; }
        public string GameGenre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PlayerCount { get; set; }
        public int OwnerId { get; set; }
    }
}
