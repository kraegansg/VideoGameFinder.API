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
            var GameGenreService = new GameGenreService(userId);
            return GameGenreService;
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
    }
}
