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
    public class UserRatingController : ApiController
    {
        private UserRatingService _userRatingService = new UserRatingService();

        public IHttpActionResult Post(UserRatingCreate userRating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRatingService.CreateUserRating(userRating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            var userRating = _userRatingService.GetUserRatings();
            return Ok(userRating);
        }

        public IHttpActionResult GetUserRatingById(int id)
        {
            var userRating = _userRatingService.GetUserRatingbyId(id);
            return Ok(userRating);
        }

        public IHttpActionResult Put(UserRatingEdit userRating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_userRatingService.UpdateUserRating(userRating))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (!_userRatingService.DeleteUserRating(id))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
