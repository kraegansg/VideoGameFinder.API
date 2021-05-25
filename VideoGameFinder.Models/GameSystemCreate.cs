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
    
        [Display(Name = "System Name")]
        public int GameSystemId { get; set; }

        //Had this above and didnt know how to deal with it. Never casted as an arry. No way to give min and max length. Generally try nto set a value on. 
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string GameSystemName { get; set; }
        public string GameForSystem { get; set; }
        public decimal GameSystemPrice { get; set; }

    }
}
