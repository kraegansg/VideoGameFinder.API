using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameFinder.Data
{
    public class GameGenre
    {
        [Key]
        public int GameGenreID { get; set; }
        [Required]
        public string GenreType { get; set; }
        public bool IsNew { get; set; }
        public bool IsMultiplayer { get; set; }
    }
}
