using Captivist.Core.Models;
using Captivist.Core.Services;
using CaptivistApp.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CaptivistApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/comments
        [HttpGet]
        public IActionResult GetComments()
        {
            var comments = _commentService.GetAll().ToList();
            return Ok(comments.ToApiModels());
        }

        // GET: api/comments/5
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            try
            {
                var comment = _commentService.Get(id);
                if (comment == null) return NotFound();

                return Ok(comment.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetComment", ex.Message);
                return BadRequest(ModelState);
            }
        }

       
        //POST api/comments
        public IActionResult Post([FromBody] Comment comment)
        {
            try
            {
                return Ok(_commentService.Add(comment).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddComment", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/comment/5
        [HttpPut("{id}")]
        
        public IActionResult Put(int id, [FromBody] Comment comment)
        {
            try
            {
                return Ok(_commentService.Update(comment).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateComment", ex.Message);
                return BadRequest(ModelState);
            }
        }


        // DELETE api/comments/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _commentService.Remove(id);
                return Ok();
                    
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteComment", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}