using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VideoGameFinder.Models
{
    public class UserRatingCreate
    {
        [Required]
        [MinLength(2, ErrorMessage="Please enter at least 2 characters.")]
        [MaxLength(40, ErrorMessage ="There are too many characters.")]
        public string GameTitle { get; set; }

       //[ForeignKey]
        public int GameId { get; set; }
    }
}
