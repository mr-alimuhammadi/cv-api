using cv_api.Db;
using cv_api.DTOs;
using cv_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace cv_api.Controllers;

[Route("api/projects")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly JsonContext _context;

    public ProjectController()
    {
        _context = new JsonContext();
    }

    [HttpGet]
    public IActionResult GetAllProjects()
    {
        return Ok(_context.Db.Projects);
    }

    [HttpGet("{id}")]
    public IActionResult GetProjectById(int id)
    {
        var project = _context.Db.Projects.SingleOrDefault(project => project.Id == id);
        if (project == null) return NotFound();
        return Ok(project);
    }

    [HttpPost]
    public IActionResult AddProject([FromBody] ProjectPostDto projectPostDto)
    {
        try
        {
            var id = 0;
            if (_context.Db.Projects.Count != 0)
                id = _context.Db.Projects[^1].Id + 1;

            var project = projectPostDto.ToProject(id);

            var user = _context.Db.Users.SingleOrDefault(u => u.Id == project.UserId);
            if (user == null) return NotFound();

            user.ProjectsIds.Add(id);
            _context.Db.Projects.Add(project);
            _context.Save();

            var result = GetProjectById(id) as OkObjectResult;
            return CreatedAtAction(nameof(GetProjectById), new { id }, result?.Value);
        }
        catch (Exception e)
        {
            return Conflict($"Could not add the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProject(int id, [FromBody] ProjectPutDto projectPutDto)
    {
        var project = _context.Db.Projects.SingleOrDefault(project => project.Id == id);
        if (project == null) return NotFound();
        try
        {
            project.Name = projectPutDto.Name;
            project.FromYear = projectPutDto.FromYear;
            project.ToYear = projectPutDto.ToYear;
            project.Details = projectPutDto.Details;
            project.Image = projectPutDto.Image;
            project.Link = projectPutDto.Link;
            _context.Save();
            return Ok(project);
        }
        catch (Exception e)
        {
            return Conflict($"Could not update the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveProject(int id)
    {
        var project = _context.Db.Projects.SingleOrDefault(project => project.Id == id);
        if (project == null) return NotFound();
        try
        {
            var user = _context.Db.Users.SingleOrDefault(user => user.Id == project.UserId)!;
            user.ProjectsIds.Remove(project.Id);
            _context.Db.Projects.Remove(project);
            _context.Save();
            return NoContent();
        }
        catch (Exception e)
        {
            return Conflict($"Could not delete the item due to a conflict.\nError Message: {e.Message}");
        }
    }
}