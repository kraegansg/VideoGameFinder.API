using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VideoGameFinder.Models
{
   public class UserRatingDetail
    {
        public int UserId { get; set; }
        public string GameTitle { get; set; }
    }
}
