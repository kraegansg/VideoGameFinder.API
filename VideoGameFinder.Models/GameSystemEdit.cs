using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameFinder.Models
{
    public class GameSystemEdit
    {
        public int GameSystemId { get; set; }
        public string GameSystemName { get; set; }
        public string GameForSystem { get; set; }
        public decimal GameSystemPrice { get; set; }

    }
}
