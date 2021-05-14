using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameFinder.Models
{


    public class GameSystemCreate
    {
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
    
        [Display(Name = "System Name")]
        public string SystemName { get; set; }
        public string GameForSystem { get; set; }
        public decimal GameSystemPrice { get; set; }

    }
}
