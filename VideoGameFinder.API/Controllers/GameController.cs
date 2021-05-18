using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VideoGameFinder.Models;

namespace VideoGameFinder.API.Controllers
{
    public class GameController
    {
            private GameService CreateGameService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var gameService = new GameService(userId);
                return gameService;
            }

            public IHttpActionResult Get()
            {
                GameService gameService = CreateGameService();
                var game = gameService.GetGame();
                return Ok(game);
            }

            public IHttpActionResult Post(GameCreate game)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateGameService();

                if (!service.CreateGame(game))
                    return InternalServerError();

                return Ok();
            }

            public IHttpActionResult Get(int id)
            {
                GameService gameService = CreateGameService();
                var game = gameService.GetGameById(id);
                return Ok(game);
            }

            public IHttpActionResult Put(GameEdit note)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateGameService();

                if (!service.UpdateGame(game))
                    return InternalServerError();

                return Ok();
            }

            public IHttpActionResult Delete(int id)
            {
                var service = CreateGameService();

                if (!service.DeleteGame(id))
                    return InternalServerError();

                return Ok();
            }
        }
    }
}