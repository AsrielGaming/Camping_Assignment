using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("[controller]")]
    public class CampingGroundController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public CampingGroundController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        [HttpPost]
        public ActionResult Post(CampingGround campingGround)
        {
            _data.AddCampingGround(campingGround);
            return Ok("Camping ground created");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCampingGround(int id, CampingGround updatedCampingGround)
        {
            _data.UpdateCampingGround(id, updatedCampingGround);
            return Ok("Camping ground updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCampingGround(int id)
        {
            _data.DeleteCampingGround(id);
            return Ok("Camping ground deleted");
        }

        [HttpGet]
        public ActionResult<IEnumerable<CampingGround>> GetCampingGrounds()
        {
            return Ok(_data.GetCampingGrounds());
        }

        [HttpGet("{id}/name")]
        public ActionResult<string> GetName(int id)
        {
            return Ok(_data.GetName(id));
        }

        [HttpGet("{id}/amountOfCampingSpots")]
        public ActionResult<int> GetAmountOfCampingSpots(int id)
        {
            return Ok(_data.GetAmountOfCampingSpots(id));
        }

        [HttpGet("{id}/location")]
        public ActionResult<string> GetLocation(int id)
        {
            return Ok(_data.GetLocation(id));
        }

        [HttpGet("{id}/isPetFriendly")]
        public ActionResult<bool> GetIsPetFriendly(int id)
        {
            return Ok(_data.GetIsPetFriendly(id));
        }
    }
}
