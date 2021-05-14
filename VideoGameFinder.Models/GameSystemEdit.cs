using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameFinder.Models
{
    public class GameSystemEdit
    {
        public int GameSystemID { get; set; }
        public string SystemName { get; set; }
        public string GameForSystem { get; set; }
        public decimal GameSystemPrice { get; set; }

    }
}
