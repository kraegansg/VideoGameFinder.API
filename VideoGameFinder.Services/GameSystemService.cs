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
        public bool CreateGameSystem(GameSystemCreate model)
        {
            var entity =
                new GameSystem()
                {
                    SystemName = model.SystemName,
                    GameForSystem = model.GameForSystem,
                    GameSystemPrice = model.GameSystemPrice
                    //entity and add it to the database table. 
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
                        .Select(
                            e =>
                            new GameSystemListItems
                            {
                                GameSystemId = e.GameSystemId,//check
                                SystemName = e.SystemName,
                                GameForSystem = e.GameForSystem,
                                GameSystemPrice = e.GameSystemPrice
                            }
                            );
                return query.ToArray();
            }
        }
        public GameSystemDetail GetGameSystemById(int gameSystemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameSystems
                        .Single(e => e.GameSystemId == gameSystemId);
                return
                    new GameSystemDetail
                    {
                        GameSystemId = entity.GameSystemId,
                        SystemName = entity.SystemName,
                        GameForSystem = entity.GameForSystem,
                        GameSystemPrice = entity.GameSystemPrice
                    };
            }
        }
        public bool UpdateGameSystem(GameSystemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameSystems
                        .Single(e => e.SystemName == model.SystemName); //question do you change out the gamesystemid since you wouldn't want IU to change the id. 

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
                    .Single(e => e.GameSystemId == gameSystemId);

                ctx.GameSystems.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
