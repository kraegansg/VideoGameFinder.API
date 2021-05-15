using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameFinder.Data
{
    public class GameSystem
    {
        [Key]
        public int GameSystemId { get; set; }
        [Required]
        public string SystemName { get; set; }
        [Required]
        public string GameForSystem { get; set; }
        public decimal GameSystemPrice { get; set; }
    }
}
