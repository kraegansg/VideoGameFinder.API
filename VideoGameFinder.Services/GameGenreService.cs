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
                    GameGenreId = model.GameGenreId,
                    GenreType = model.GenreType,
                    IsMultiplayer = model.IsMultiplayer,
                    IsNew = model.IsNew



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
                                GameGenreId = e.GameGenreId,
                                GenreType = e.GenreType,
                                IsMultiplayer = e.IsMultiplayer,
                                IsNew = e.IsNew
                            }
                            );
                return query.ToArray();
            }
        }

        // Update Game Genre Method
        public bool UpdateGameGenre(GameGenreEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameGenres
                        .Single(e => e.GameGenreId == model.GameGenreId);

                entity.GameGenreId = model.GameGenreId;
                entity.GenreType = model.GenreType;
                entity.IsNew = model.IsNew;
                entity.IsMultiplayer = model.IsMultiplayer;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete Game Genre Method 
        public bool DeleteGameGenre(int gameGenreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .GameGenres
                    .Single(e => e.GameGenreId == gameGenreId);

                ctx.GameGenres.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        // Get Game Genre by Genre Type 
        public GameGenreDetail GetGameGenreByType(string gameGenreType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GameGenres
                    .Single(e => e.GenreType == gameGenreType);

                // No user ID needed
                return
                    new GameGenreDetail
                    {
                        GameGenreId = entity.GameGenreId,
                        GenreType = entity.GenreType,
                        IsMultiplayer = entity.IsMultiplayer,
                        IsNew = entity.IsNew
                    };
            }
        }

        // Get Game Genre By ID
        public GameGenreDetail GetGameGenreById(int gameGenreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameGenres
                        .Single(e => e.GameGenreId == gameGenreId);
                return
                    new GameGenreDetail
                    {
                        GameGenreId = entity.GameGenreId,
                        GenreType = entity.GenreType,
                        IsMultiplayer = entity.IsMultiplayer,
                        IsNew = entity.IsNew
                    };
            }
        }



    }
}



