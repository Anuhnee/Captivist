using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Captivist.Core.Services;
using Microsoft.AspNetCore.Mvc;
using CaptivistApp.ApiModels;
using Captivist.Core.Models;


namespace CaptivistApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET api/reviews
        [HttpGet]
        public IActionResult GetReviews()
        {
            var reviews = _reviewService.GetAll().ToList();
            return Ok(reviews.ToApiModels());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var review = _reviewService.Get(id);
                if (review == null) return NotFound();

                return Ok(review.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetReview", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/reviews
        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            try
            {
                return Ok(_reviewService.Add(review).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("AddReview", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/reviews/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review review)
        {
            try
            {
                return Ok(_reviewService.Update(review).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateReview", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/reviews/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _reviewService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteReview", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
