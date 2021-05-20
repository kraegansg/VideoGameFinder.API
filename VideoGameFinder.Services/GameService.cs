using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameFinder.Data;
using VideoGameFinder.Models;

namespace VideoGameFinder.Services
{
    public class GameService
    {
        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    OwnerId = _userId,
                    GameTitle = model.GameTitle,
                    ReleaseDate = model.ReleaseDate,
                    PlayerCount = model.PlayerCount,
                    GameSystem = model.GameSystem,
                    ESRBRating = model.ESRBRating,
                    IsReccommended = model.IsReccommended,
                    GamePrice = model.GamePrice,
                    GameGenre = model.GameGenre
                };
    

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetGame()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    GameId = e.GameId,
                                    GameTitle = e.GameTitle
                                }
                        );

                return query.ToArray();
            }
        }

        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == id && e.OwnerId == _userId);
                return
                    new GameDetail
                    {
                        GameId = entity.GameId,
                        GameTitle = entity.GameTitle
                    };
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == model.GameId && e.OwnerId == _userId);

                entity.GameTitle = model.GameTitle;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == GameId && e.OwnerId == _userId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
