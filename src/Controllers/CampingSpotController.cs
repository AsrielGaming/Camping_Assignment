using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("[controller]")]
    public class CampingSpotController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public CampingSpotController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        [HttpPost]
        public ActionResult Post(CampingSpot campingSpot)
        {
            _data.AddCampingSpot(campingSpot);
            return Ok("Camping spot created");
        }

        [HttpGet]
        public ActionResult<IEnumerable<CampingSpot>> GetCampingSpots()
        {
            return Ok(_data.GetCampingSpots());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCampingSpot(int id, CampingSpot updatedCampingSpot)
        {
            _data.UpdateCampingSpot(id, updatedCampingSpot);
            return Ok("Camping spot updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCampingSpot(int id)
        {
            _data.DeleteCampingSpot(id);
            return Ok("Camping spot deleted");
        }

        [HttpGet("byOwner/{ownerId}")]
        public ActionResult<IEnumerable<CampingSpot>> GetCampingSpotsByOwner(int ownerId)
        {
            return Ok(_data.GetCampingSpotsByOwner(ownerId));
        }

        [HttpGet("byCampingGround/{campingGroundId}")]
        public ActionResult<IEnumerable<CampingSpot>> GetCampingSpotsByCampingGround(int campingGroundId)
        {
            return Ok(_data.GetCampingSpotsByCampingGround(campingGroundId));
        }

        [HttpGet("{id}/spotName")]
        public ActionResult<string> GetSpotName(int id)
        {
            return Ok(_data.GetSpotName(id));
        }

        [HttpGet("{id}/size")]
        public ActionResult<int> GetSize(int id)
        {
            return Ok(_data.GetSize(id));
        }

        [HttpGet("{id}/description")]
        public ActionResult<string> GetDescription(int id)
        {
            return Ok(_data.GetDescription(id));
        }

        [HttpGet("{id}/price")]
        public ActionResult<decimal> GetPrice(int id)
        {
            return Ok(_data.GetPrice(id));
        }

        [HttpGet("{id}/isAvailable")]
        public ActionResult<bool> GetIsAvailable(int id)
        {
            return Ok(_data.GetIsAvailable(id));
        }
    }
}
