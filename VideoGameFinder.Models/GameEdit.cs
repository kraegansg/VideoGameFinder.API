using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameFinder.Models
{
    public class GameEdit
    {
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public double GamePrice { get; set; }
        public string GameSystem { get; set; }
    }
}
