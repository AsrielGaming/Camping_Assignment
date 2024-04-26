using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("[controller]")]
    public class CampTypeController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public CampTypeController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        [HttpPost]
        public ActionResult Post(Camptype campType)
        {
            _data.AddCampType(campType);
            return Ok("Camp type created");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCampType(int id, Camptype updatedCampType)
        {
            _data.UpdateCampType(id, updatedCampType);
            return Ok("Camp type updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCampType(int id)
        {
            _data.DeleteCampType(id);
            return Ok("Camp type deleted");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Camptype>> GetCampTypes()
        {
            return Ok(_data.GetCampTypes());
        }
    }
}
