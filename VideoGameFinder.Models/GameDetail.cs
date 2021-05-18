using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameFinder.Models
{
    public class GameDetail
    {
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PlayerCount { get; set; }

    }
}
