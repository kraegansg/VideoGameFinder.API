using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameFinder.Models
{
    public class GameGenreCreate
    {
        [Required]
        [MaxLength(25)]
        public string GenreType { get; set; }
        public bool IsNew { get; set; }
        public bool IsMultiplayer { get; set; }
    }
}
