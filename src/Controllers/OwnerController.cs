using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public OwnerController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Owner>> GetOwners()
        {
            return Ok(_data.GetOwners());
        }

        [HttpPost]
        public ActionResult Post(Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _data.AddOwner(owner);
            return Ok("Owner created");
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> GetOwner(int id)
        {
            var owner = _data.GetOwnerById(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOwner(int id)
        {
            _data.DeleteOwner(id);
            return Ok("Owner deleted");
        }

        [HttpPut("{id}/name")]
        public ActionResult UpdateOwnerName(int id, string newName)
        {
            _data.UpdateOwnerName(id, newName);
            return Ok("Owner name updated");
        }

        [HttpPut("{id}/email")]
        public ActionResult UpdateOwnerEmail(int id, string newEmail)
        {
            _data.UpdateOwnerEmail(id, newEmail);
            return Ok("Owner email updated");
        }

        [HttpPut("{id}/password")]
        public ActionResult UpdateOwnerPassword(int id, string newPassword)
        {
            _data.UpdateOwnerPassword(id, newPassword);
            return Ok("Owner password updated");
        }

        [HttpPut("{id}/phone")]
        public ActionResult UpdateOwnerPhoneNumber(int id, string newPhoneNumber)
        {
            _data.UpdateOwnerPhoneNumber(id, newPhoneNumber);
            return Ok("Owner phone number updated");
        }
    }
}
