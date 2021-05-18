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


        public bool CreateGameGenre(GameGenreCreate model)
        {
            var entity =
                new GameGenre()
                {
                    OwnerId = _userId,
                    GenreType = model.GenreType

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameGenres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
