using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("[controller]")]
    public class AmenityController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public AmenityController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        [HttpPost]
        public ActionResult Post(Amenity amenity)
        {
            _data.AddAmenity(amenity);
            return Ok("Amenity created");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAmenity(int id, Amenity updatedAmenity)
        {
            _data.UpdateAmenity(id, updatedAmenity);
            return Ok("Amenity updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAmenity(int id)
        {
            _data.DeleteAmenity(id);
            return Ok("Amenity deleted");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Amenity>> GetAmenities()
        {
            return Ok(_data.GetAmenities());
        }
    }
}
