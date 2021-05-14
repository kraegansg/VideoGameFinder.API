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
        private readonly Guid _userId;
        public GameSystemService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGameSystem(GameSystemCreate model)
        {
            var entity =
                new GameSystem()
                {
                    GameSystemID = userId,
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
                        .Where(e => e.GameSystemID = _userId)
                        .Select(
                            e)
            }
        }
    }
}
