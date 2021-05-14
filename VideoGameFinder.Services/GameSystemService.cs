using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameFinder.Data;
using VideoGameFinder.Models;

namespace VideoGameFinder.Services
{
    public class GameSystemService
    {
        //private readonly Guid _userId;
        //public GameSystemService(Guid userId)
        //{
        //    _userId = userId;
        //}
        public bool CreateGameSystem(GameSystemCreate model)
        {
            var entity =
                new GameSystem()
                {
                    GameSystemID = model.GameSystemID,
                    SystemName = model.SystemName,
                    GameForSystem = model.GameForSystem,
                    GameSystemPrice = model.GameSystemPrice

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameSystems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameSystemListItems> GetGameSystems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .GameSystems
                        .Where(e => e.GameSystemID )
                        .Select(
                            e =>
                            new GameSystemListItems
                            {
                                SystemName = e.SystemName,
                                GameForSystem = e.GameForSystem,
                                GameSystemPrice = e.GameSystemPrice
                            }
                            );
                return query.ToArray();
            }
        }
        public GameSystemDetail GetGameSystemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameSystems
                        .Single(e => e.GameSystemID == id && e.SystemName);
                return
                    new GameSystemDetail
                    {
                        SystemName = entity.SystemName,
                        GameForSystem = entity.GameSystem,
                        GameSystemPrice = entity.GameSystemPrice
                    };
            }
        }
        public bool UpdateGameSystems(GameSystemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameSystems
                        .Single(e => e.GameSystemID == model.GameSystemID);

                entity.SystemName = entity.SystemName;
                entity.GameForSystem = entity.GameForSystem;
                entity.GameSystemPrice = entity.GameSystemPrice;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGameSystem(int gameSystemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .GameSystems
                    .Single(e => e.GameSystemID == gameSystemId);

                ctx.GameSystems.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
