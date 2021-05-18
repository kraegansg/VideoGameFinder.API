using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoGameFinder.Models;
using VideoGameFinder.Services;

namespace VideoGameFinder.API.Controllers
{
    [Authorize]
    public class GameSystemController : ApiController
    {
       public IHttpActionResult Get()
        {
            var cGameSystemService = CreateGameSystemService();
            var gamesystems = cGameSystemService.GetGameSystems();
            return Ok(gamesystems);
        }
        public IHttpActionResult Post(GameSystemCreate gameSystem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gsService = CreateGameSystemService();

            if (!gsService.CreateGameSystem(gameSystem))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            var gsService = CreateGameSystemService();
            var gameSystem = gsService.GetGameSystemById(id);
            return Ok(gameSystem);
        }
        public IHttpActionResult Put(GameSystemEdit id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameSystemService();

            if (!service.UpdateGameSystem(id))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var gsService = CreateGameSystemService();

            if (!gsService.DeleteGameSystem(id))
                return InternalServerError();

            return Ok();
        }

        private GameSystemService CreateGameSystemService()
        {
            var gameSystemService = new GameSystemService();
            return gameSystemService;
        }
    }
}
