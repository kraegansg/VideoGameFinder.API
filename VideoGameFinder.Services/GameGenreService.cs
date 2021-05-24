using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameFinder.Data;
using VideoGameFinder.Models;

namespace VideoGameFinder.Services
{
    public class GameGenreService
    {
        private readonly Guid _userId;

        public GameGenreService(Guid userId)
        {
            _userId = userId;
        }

        // Create New Game Genre Method 
        public bool CreateGameGenre(GameGenreCreate model)
        {
            var entity =
                new GameGenre()
                {
                    // !! I don't think we need this - UserId = _userId,
                    GenreType = model.GenreType

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameGenres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // View All Game Genres Method 
        public IEnumerable<GameGenreItem> GetGameGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .GameGenres
                        .Select(
                        e =>
                            new GameGenreItem
                            {
                                GameGenreID = e.GameGenreID,
                                GenreType = e.GenreType,
                                IsMultiplayer = e.IsMultiplayer,
                                IsNew = e.IsNew
                            }
                            );
                return query.ToArray();
            }
        }

        // Update Game Genre Method
        

        // Delete Game Genre Method 

        // Get Game Genre by Genre Type 
        public GameGenreDetail GetGameGenreByType(string gameGenreType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GameGenres;

                    // No user ID needed
                return
                    new GameGenreDetail
                    {
                        GameGenreID = entity.GameGenreID,
                        GenreType = entity.GenreType,
                        IsMultiplayer = entity.IsMultiplayer,
                        IsNew = entity.IsNew
                    };
            }
        }



    }
}
