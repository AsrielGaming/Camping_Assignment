using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public RatingController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        [HttpPost]
        public ActionResult Post(Rating rating)
        {
            _data.AddRating(rating);
            return Ok("Rating created");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rating>> GetRatings()
        {
            return Ok(_data.GetRatings());
        }

        [HttpGet("byCampingSpot/{campingSpotId}")]
        public ActionResult<IEnumerable<Rating>> GetRatingsByCampingSpot(int campingSpotId)
        {
            return Ok(_data.GetRatingsByCampingSpot(campingSpotId));
        }

        [HttpGet("byUser/{userId}")]
        public ActionResult<IEnumerable<Rating>> GetRatingsByUser(int userId)
        {
            return Ok(_data.GetRatingsByUser(userId));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRating(int id)
        {
            _data.DeleteRating(id);
            return Ok("Rating deleted");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRating(int id, Rating updatedRating)
        {
            _data.UpdateRating(id, updatedRating);
            return Ok("Rating updated");
        }

        [HttpGet("{id}/score")]
        public ActionResult<int> GetRatingScore(int id)
        {
            return Ok(_data.GetRatingScore(id));
        }

    }
}
