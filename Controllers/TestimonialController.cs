using cv_api.Db;
using cv_api.DTOs;
using cv_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace cv_api.Controllers;

[Route("api/testimonial")]
[ApiController]
public class TestimonialController : ControllerBase
{
    private readonly JsonContext _context;

    public TestimonialController()
    {
        _context = new JsonContext();
    }

    [HttpGet]
    public IActionResult GetAllTestimonials()
    {
        return Ok(_context.Db.Testimonials);
    }

    [HttpGet("{id}")]
    public IActionResult GetTestimonialById(int id)
    {
        var testimonial = _context.Db.Testimonials.SingleOrDefault(testimonial => testimonial.Id == id);
        if (testimonial == null) return NotFound();
        return Ok(testimonial);
    }

    [HttpPost]
    public IActionResult AddTestimonial([FromBody] TestimonialPostDto testimonialPostDto)
    {
        try
        {
            var id = 0;
            if (_context.Db.Testimonials.Count != 0)
                id = _context.Db.Testimonials[^1].Id + 1;

            var testimonial = testimonialPostDto.ToTestimonial(id);

            var user = _context.Db.Users.SingleOrDefault(u => u.Id == testimonial.UserId);
            if (user == null) return NotFound();

            user.TestimonialsIds.Add(id);
            _context.Db.Testimonials.Add(testimonial);
            _context.Save();

            var result = GetTestimonialById(id) as OkObjectResult;
            return CreatedAtAction(nameof(GetTestimonialById), new { id }, result?.Value);
        }
        catch (Exception e)
        {
            return Conflict($"Could not add the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTestimonial(int id, [FromBody] TestimonialPutDto testimonialPutDto)
    {
        var testimonial = _context.Db.Testimonials.SingleOrDefault(testimonial => testimonial.Id == id);
        if (testimonial == null) return NotFound();
        try
        {
            testimonial.ClientName = testimonialPutDto.ClientName;
            testimonial.ClientJob = testimonialPutDto.ClientJob;
            testimonial.ClientImage = testimonialPutDto.ClientImage;
            testimonial.Comment = testimonialPutDto.Comment;
            _context.Save();
            return Ok(testimonial);
        }
        catch (Exception e)
        {
            return Conflict($"Could not update the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveTestimonial(int id)
    {
        var testimonial = _context.Db.Testimonials.SingleOrDefault(testimonial => testimonial.Id == id);
        if (testimonial == null) return NotFound();
        try
        {
            var user = _context.Db.Users.SingleOrDefault(user => user.Id == testimonial.UserId)!;
            user.TestimonialsIds.Remove(testimonial.Id);
            _context.Db.Testimonials.Remove(testimonial);
            _context.Save();
            return NoContent();
        }
        catch (Exception e)
        {
            return Conflict($"Could not delete the item due to a conflict.\nError Message: {e.Message}");
        }
    }
}