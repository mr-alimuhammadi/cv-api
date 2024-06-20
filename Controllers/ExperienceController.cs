using cv_api.Db;
using cv_api.DTOs;
using cv_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace cv_api.Controllers;

[Route("api/experiences")]
[ApiController]
public class ExperienceController : ControllerBase
{
    private readonly JsonContext _context;

    public ExperienceController()
    {
        _context = new JsonContext();
    }

    [HttpGet]
    public IActionResult GetAllExperiences()
    {
        return Ok(_context.Db.Experiences);
    }

    [HttpGet("{id}")]
    public IActionResult GetExperienceById(int id)
    {
        var experience = _context.Db.Experiences.SingleOrDefault(experience => experience.Id == id);
        if (experience == null) return NotFound();
        return Ok(experience);
    }

    [HttpPost]
    public IActionResult AddExperience([FromBody] ExperiencePostDto experiencePostDto)
    {
        try
        {
            var id = 0;
            if (_context.Db.Experiences.Count != 0)
                id = _context.Db.Experiences[^1].Id + 1;

            var experience = experiencePostDto.ToExperience(id);

            var user = _context.Db.Users.SingleOrDefault(u => u.Id == experience.UserId);
            if (user == null) return NotFound();

            user.ExperiencesIds.Add(id);
            _context.Db.Experiences.Add(experience);
            _context.Save();

            var result = GetExperienceById(id) as OkObjectResult;
            return CreatedAtAction(nameof(GetExperienceById), new { id }, result?.Value);
        }
        catch (Exception e)
        {
            return Conflict($"Could not add the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateExperience(int id, [FromBody] ExperiencePutDto experiencePutDto)
    {
        var experience = _context.Db.Experiences.SingleOrDefault(experience => experience.Id == id);
        if (experience == null) return NotFound();
        try
        {
            experience.FromYear = experiencePutDto.FromYear;
            experience.ToYear = experiencePutDto.ToYear;
            experience.Job = experiencePutDto.Job;
            experience.Company = experiencePutDto.Company;
            experience.Details = experiencePutDto.Details;
            _context.Save();
            return Ok(experience);
        }
        catch (Exception e)
        {
            return Conflict($"Could not update the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveExperience(int id)
    {
        var experience = _context.Db.Experiences.SingleOrDefault(experience => experience.Id == id);
        if (experience == null) return NotFound();
        try
        {
            var user = _context.Db.Users.SingleOrDefault(user => user.Id == experience.UserId)!;
            user.ExperiencesIds.Remove(experience.Id);
            _context.Db.Experiences.Remove(experience);
            _context.Save();
            return NoContent();
        }
        catch (Exception e)
        {
            return Conflict($"Could not delete the item due to a conflict.\nError Message: {e.Message}");
        }
    }
}