using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VideoGameFinder.Services
{
    public class UserRatingService
    {
        public bool CreateUserRating(UserRatingCreate model)
        {
            var entity =
                new UserRating()
                {
                    GameTitle = model.GameTitle
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserRatings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserRatingListItem> GetUserRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .UserRatings
                    .Select(
                        e =>
                        new UserRatingListItem
                        {
                            UserId = e.UserId,
                            GameTitle = e.GameTitle
                        });
                return query.ToArray();
            }
        }

        public UserRatingDetail GetUserRatingbyId (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

            }
        }
    }

    internal class UserRatingListItem
    {
        public object UserId { get; set; }
        public object GameTitle { get; set; }
    }
}
