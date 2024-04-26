using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public UserController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // User methodes
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_data.GetUsers());
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            _data.AddUser(user);
            return Ok("User created");
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _data.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}/username")]
        public ActionResult UpdateUsername(int id, string newUsername)
        {
            _data.UpdateUsername(id, newUsername);
            return Ok("Username updated");
        }

        [HttpPut("{id}/password")]
        public ActionResult UpdatePassword(int id, string newPassword)
        {
            _data.UpdatePassword(id, newPassword);
            return Ok("Password updated");
        }

        [HttpPut("{id}/email")]
        public ActionResult UpdateEmail(int id, string newEmail)
        {
            _data.UpdateEmail(id, newEmail);
            return Ok("Email updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            _data.DeleteUser(id);
            return Ok("User deleted");
        }
    }
}
