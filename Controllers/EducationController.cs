using cv_api.Db;
using cv_api.DTOs;
using cv_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace cv_api.Controllers;

[Route("api/educations")]
[ApiController]
public class EducationController : ControllerBase
{
    private readonly JsonContext _context;

    public EducationController()
    {
        _context = new JsonContext();
    }

    [HttpGet]
    public IActionResult GetAllEducations()
    {
        return Ok(_context.Db.Educations);
    }

    [HttpGet("{id}")]
    public IActionResult GetEducationById(int id)
    {
        var education = _context.Db.Educations.SingleOrDefault(education => education.Id == id);
        if (education == null) return NotFound();
        return Ok(education);
    }

    [HttpPost]
    public IActionResult AddEducation([FromBody] EducationPostDto educationPostDto)
    {
        try
        {
            var id = 0;
            if (_context.Db.Educations.Count != 0)
                id = _context.Db.Educations[^1].Id + 1;

            var education = educationPostDto.ToEducation(id);

            var user = _context.Db.Users.SingleOrDefault(u => u.Id == education.UserId);
            if (user == null) return NotFound();

            user.EducationsIds.Add(id);
            _context.Db.Educations.Add(education);
            _context.Save();

            var result = GetEducationById(id) as OkObjectResult;
            return CreatedAtAction(nameof(GetEducationById), new { id }, result?.Value);
        }
        catch (Exception e)
        {
            return Conflict($"Could not add the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEducation(int id, [FromBody] EducationPutDto educationPutDto)
    {
        var education = _context.Db.Educations.SingleOrDefault(education => education.Id == id);
        if (education == null) return NotFound();
        try
        {
            education.EndYear = educationPutDto.EndYear;
            education.Major = educationPutDto.Major;
            education.School = educationPutDto.School;
            education.Details = educationPutDto.Details;
            _context.Save();
            return Ok(education);
        }
        catch (Exception e)
        {
            return Conflict($"Could not update the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveEducation(int id)
    {
        var education = _context.Db.Educations.SingleOrDefault(education => education.Id == id);
        if (education == null) return NotFound();
        try
        {
            var user = _context.Db.Users.SingleOrDefault(user => user.Id == education.UserId)!;
            user.EducationsIds.Remove(education.Id);
            _context.Db.Educations.Remove(education);
            _context.Save();
            return NoContent();
        }
        catch (Exception e)
        {
            return Conflict($"Could not delete the item due to a conflict.\nError Message: {e.Message}");
        }
    }
}