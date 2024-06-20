using cv_api.Db;
using cv_api.DTOs;
using cv_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace cv_api.Controllers;

[Route("api/professions")]
[ApiController]
public class ProfessionController : ControllerBase
{
    private readonly JsonContext _context;

    public ProfessionController()
    {
        _context = new JsonContext();
    }

    [HttpGet]
    public IActionResult GetAllProfessions()
    {
        return Ok(_context.Db.Professions);
    }

    [HttpGet("{id}")]
    public IActionResult GetProfessionById(int id)
    {
        var profession = _context.Db.Professions.SingleOrDefault(profession => profession.Id == id);
        if (profession == null) return NotFound();
        return Ok(profession);
    }

    [HttpPost]
    public IActionResult AddProfession([FromBody] ProfessionPostDto professionPostDto)
    {
        try
        {
            var id = 0;
            if (_context.Db.Professions.Count != 0)
                id = _context.Db.Professions[^1].Id + 1;

            var profession = professionPostDto.ToProfession(id);

            var user = _context.Db.Users.SingleOrDefault(u => u.Id == profession.UserId);
            if (user == null) return NotFound();

            user.ProfessionsIds.Add(id);
            _context.Db.Professions.Add(profession);
            _context.Save();

            var result = GetProfessionById(id) as OkObjectResult;
            return CreatedAtAction(nameof(GetProfessionById), new { id }, result?.Value);
        }
        catch (Exception e)
        {
            return Conflict($"Could not add the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProfession(int id, [FromBody] ProfessionPutDto professionPutDto)
    {
        var profession = _context.Db.Professions.SingleOrDefault(profession => profession.Id == id);
        if (profession == null) return NotFound();
        try
        {
            profession.Title = professionPutDto.Title;
            profession.Details = professionPutDto.Details;
            profession.Icon = professionPutDto.Icon;
            _context.Save();
            return Ok(profession);
        }
        catch (Exception e)
        {
            return Conflict($"Could not update the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveProfession(int id)
    {
        var profession = _context.Db.Professions.SingleOrDefault(profession => profession.Id == id);
        if (profession == null) return NotFound();
        try
        {
            var user = _context.Db.Users.SingleOrDefault(user => user.Id == profession.UserId)!;
            user.ProfessionsIds.Remove(profession.Id);
            _context.Db.Professions.Remove(profession);
            _context.Save();
            return NoContent();
        }
        catch (Exception e)
        {
            return Conflict($"Could not delete the item due to a conflict.\nError Message: {e.Message}");
        }
    }
}