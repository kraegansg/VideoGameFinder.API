using Microsoft.AspNet.Identity;
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
    public class GameGenreController : ApiController
    {
        // Method that creates Game Genre Service
        private GameGenreService CreateGameGenreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var gameGenreService = new GameGenreService(userId);
            return gameGenreService;
        }

        // Get All Method
        public IHttpActionResult Get()
        {
            GameGenreService gameGenreService = CreateGameGenreService();
            var gameGenres = gameGenreService.GetGameGenres();
            return Ok(gameGenres);
        }

        // Post Method 
        public IHttpActionResult Post(GameGenreCreate gameGenre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameGenreService();

            if (!service.CreateGameGenre(gameGenre))
                return InternalServerError();

            return Ok();
        }

        // Put Method
        public IHttpActionResult Put(GameGenreEdit gameGenre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameGenreService();

            if (!service.UpdateGameGenre(gameGenre))
                return InternalServerError();

            return Ok();
        }

        // Delete Method
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGameGenreService();

            if (!service.DeleteGameGenre(id))
                return InternalServerError();

            return Ok();
        }
    }

}

