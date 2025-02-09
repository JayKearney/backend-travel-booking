using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TravelBooking_Backend_Jesica.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly ILogger<ReviewController> _logger;
    private readonly AppDbContext _dbContext;
    public ReviewController(ILogger<ReviewController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet("GetReviews")]
    public IActionResult GetReviews(){
    List<Review> dummyReviews = new List<Review>(); 
    dummyReviews = _dbContext.Reviews.ToList();
    return Ok(dummyReviews);
    }


    [HttpPost("AddReview")]
    public IActionResult AddReview([FromBody] Review newReview)
    {
        // Add the new review to the database
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _dbContext.Reviews.Add(newReview);
        _dbContext.SaveChanges();
        //return Ok("Review added successfully!");
        return CreatedAtAction(nameof(GetReviews), new { id = newReview.Id }, newReview);
    }


    [HttpPut("UpdateReview/{id}")]
    public IActionResult UpdateReview(int id, [FromBody] Review updatedReview)
    {
        if(updatedReview == null || id != updatedReview.Id)
        {
            return BadRequest("Review data is undefined");
        }
        // Find the review in the database
        var reviewInDb = _dbContext.Reviews.FirstOrDefault(r => r.Id == id);
        if (reviewInDb == null)
        {
            return NotFound("Review not found");
        }
        // Update the review
        reviewInDb.Name = updatedReview.Name;
        reviewInDb.Rating = updatedReview.Rating;
        reviewInDb.Comments = updatedReview.Comments;
        _dbContext.SaveChanges();
        return Ok("Review updated successfully!");
    }

    
    [HttpDelete("DeleteReview/{id}")]
    public IActionResult DeleteReview(int id)
    {
        // Find the review in the database
        if (id == null)
        {
            return BadRequest("Review ID is undefined");
        }
        var reviewInDb = _dbContext.Reviews.FirstOrDefault(r => r.Id == id);
        if (reviewInDb == null)
        {
            return NotFound("Review not found");
        }
        // Delete the review
        _dbContext.Reviews.Remove(reviewInDb);
        _dbContext.SaveChanges();
        return Ok("Review deleted successfully!");
    }

}