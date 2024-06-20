using cv_api.Db;
using cv_api.DTOs;
using cv_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace cv_api.Controllers;

[Route("api/socialMedia")]
[ApiController]
public class SocialMediaController : ControllerBase
{
    private readonly JsonContext _context;

    public SocialMediaController()
    {
        _context = new JsonContext();
    }

    [HttpGet]
    public IActionResult GetAllSocialMedias()
    {
        return Ok(_context.Db.SocialMedias);
    }

    [HttpGet("{id}")]
    public IActionResult GetSocialMediaById(int id)
    {
        var socialMedia = _context.Db.SocialMedias.SingleOrDefault(socialMedia => socialMedia.Id == id);
        if (socialMedia == null) return NotFound();
        return Ok(socialMedia);
    }

    [HttpPost]
    public IActionResult AddSocialMedia([FromBody] SocialMediaPostDto socialMediaPostDto)
    {
        try
        {
            var id = 0;
            if (_context.Db.SocialMedias.Count != 0)
                id = _context.Db.SocialMedias[^1].Id + 1;

            var socialMedia = socialMediaPostDto.ToSocialMedia(id);

            var user = _context.Db.Users.SingleOrDefault(u => u.Id == socialMedia.UserId);
            if (user == null) return NotFound();

            user.SocialMediasIds.Add(id);
            _context.Db.SocialMedias.Add(socialMedia);
            _context.Save();

            var result = GetSocialMediaById(id) as OkObjectResult;
            return CreatedAtAction(nameof(GetSocialMediaById), new { id }, result?.Value);
        }
        catch (Exception e)
        {
            return Conflict($"Could not add the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateSocialMedia(int id, [FromBody] SocialMediaPutDto socialMediaPutDto)
    {
        var socialMedia = _context.Db.SocialMedias.SingleOrDefault(socialMedia => socialMedia.Id == id);
        if (socialMedia == null) return NotFound();
        try
        {
            socialMedia.Platform = socialMediaPutDto.Platform;
            socialMedia.Link = socialMediaPutDto.Link;
            socialMedia.Icon = socialMediaPutDto.Icon;
            _context.Save();
            return Ok(socialMedia);
        }
        catch (Exception e)
        {
            return Conflict($"Could not update the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveSocialMedia(int id)
    {
        var socialMedia = _context.Db.SocialMedias.SingleOrDefault(socialMedia => socialMedia.Id == id);
        if (socialMedia == null) return NotFound();
        try
        {
            var user = _context.Db.Users.SingleOrDefault(user => user.Id == socialMedia.UserId)!;
            user.SocialMediasIds.Remove(socialMedia.Id);
            _context.Db.SocialMedias.Remove(socialMedia);
            _context.Save();
            return NoContent();
        }
        catch (Exception e)
        {
            return Conflict($"Could not delete the item due to a conflict.\nError Message: {e.Message}");
        }
    }
}