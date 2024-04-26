using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public CommentController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        [HttpPost]
        public ActionResult Post(Comment comment)
        {
            _data.AddComment(comment);
            return Ok("Comment created");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetComments()
        {
            return Ok(_data.GetComments());
        }

        [HttpGet("byCampingSpot/{campingSpotId}")]
        public ActionResult<IEnumerable<Comment>> GetCommentsByCampingSpot(int campingSpotId)
        {
            return Ok(_data.GetCommentsByCampingSpot(campingSpotId));
        }

        [HttpGet("byUser/{userId}")]
        public ActionResult<IEnumerable<Comment>> GetCommentsByUser(int userId)
        {
            return Ok(_data.GetCommentsByUser(userId));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteComment(int id)
        {
            _data.DeleteComment(id);
            return Ok("Comment deleted");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateComment(int id, Comment updatedComment)
        {
            _data.UpdateComment(id, updatedComment);
            return Ok("Comment updated");
        }

        [HttpGet("{id}/text")]
        public ActionResult<string> GetCommentText(int id)
        {
            return Ok(_data.GetCommentText(id));
        }

    }
}
