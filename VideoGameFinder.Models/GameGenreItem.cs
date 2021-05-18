using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameFinder.Models
{
    public class GameGenreItem
    {
        public int GameGenreID { get; set; }
        public string GenreType { get; set; }
        public bool IsNew { get; set; }
        public bool IsMultiplayer { get; set; }
    }
}
