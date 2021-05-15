using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VideoGameFinder.Models;
using VideoGameFinder.Data;

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

        public UserRatingDetail GetUserRatingbyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UserRatings
                    .Single(e => e.UserId == id);

                return new UserRatingDetail
                {
                    UserId = entity.UserId,
                    GameTitle = entity.GameTitle
                };
            }
        }

        public bool UpdateUserRating(UserRatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UserRatings
                    .Single(e => e.UserId == model.UserId);
                entity.GameTitle = model.GameTitle;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUserRating(int userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UserRatings
                    .Single(e => e.UserId == userId);

                ctx.UserRatings.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    } 

}
