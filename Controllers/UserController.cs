using cv_api.Db;
using cv_api.DTOs;
using cv_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace cv_api.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly JsonContext _context;

    public UserController()
    {
        _context = new JsonContext();
    }

    // GET
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(_context.Db.Users.Select(user => user.ToUserGetDto()));
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById([FromRoute] int id)
    {
        var user = _context.Db.Users.Find(user => user.Id == id);
        if (user == null) return NotFound();
        return Ok(user.ToUserGetDto());
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] UserPostDto user)
    {
        try
        {
            var id = 0;
            if (_context.Db.Users.Count != 0) id = _context.Db.Users[^1].Id + 1;
            _context.Db.Users.Add(user.ToUser(id));
            _context.Save();

            var result = GetUserById(id) as OkObjectResult;
            return CreatedAtAction(nameof(GetUserById), new { id }, result?.Value);
        }
        catch (Exception e)
        {
            return Conflict($"Could not add the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateUser([FromBody] UserPutDto userPutDto, [FromRoute] int id)
    {
        var user = _context.Db.Users.SingleOrDefault(u => u.Id == id);
        if (user == null) return NotFound();
        try
        {
            user.FullName = userPutDto.FullName;
            user.Profession = userPutDto.Profession;
            user.Profile = userPutDto.Profile;
            user.CareerObjectives = userPutDto.CareerObjectives;
            user.PhoneNumber = userPutDto.Contacts.PhoneNumber;
            user.Email = userPutDto.Contacts.Email;
            user.Address = userPutDto.Contacts.Address;
            user.HappyClients = userPutDto.Facts.HappyClients;
            user.WorkingHours = userPutDto.Facts.WorkingHours;
            user.AwardsWon = userPutDto.Facts.AwardsWon;
            user.CoffeeConsumed = userPutDto.Facts.CoffeeConsumed;
            _context.Save();
            return Ok(user.ToUserGetDto());
        }
        catch (Exception e)
        {
            return Conflict($"Could not update the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveUser([FromRoute] int id)
    {
        var user = _context.Db.Users.SingleOrDefault(user => user.Id == id);
        if (user == null) return NotFound();
        try
        {
            user.SocialMediasIds.ForEach(socialMediaId =>
            {
                var media = _context.Db.SocialMedias.SingleOrDefault(socialMedia => socialMedia.Id == socialMediaId);
                _context.Db.SocialMedias.Remove(media!);
            });
            user.ProfessionsIds.ForEach(professionId =>
            {
                var profession = _context.Db.Professions.SingleOrDefault(profession => profession.Id == professionId);
                _context.Db.Professions.Remove(profession!);
            });
            user.TestimonialsIds.ForEach(testimonialId =>
            {
                var testimonial =
                    _context.Db.Testimonials.SingleOrDefault(testimonial => testimonial.Id == testimonialId);
                _context.Db.Testimonials.Remove(testimonial!);
            });
            user.ClientsIds.ForEach(clientId =>
            {
                var client = _context.Db.Clients.SingleOrDefault(client => client.Id == clientId);
                _context.Db.Clients.Remove(client!);
            });
            user.EducationsIds.ForEach(educationId =>
            {
                var education = _context.Db.Educations.SingleOrDefault(education => education.Id == educationId);
                _context.Db.Educations.Remove(education!);
            });
            user.ExperiencesIds.ForEach(experienceId =>
            {
                var experience = _context.Db.Experiences.SingleOrDefault(experience => experience.Id == experienceId);
                _context.Db.Experiences.Remove(experience!);
            });
            user.CertificatesIds.ForEach(certificateId =>
            {
                var certificate =
                    _context.Db.Certificates.SingleOrDefault(certificate => certificate.Id == certificateId);
                _context.Db.Certificates.Remove(certificate!);
            });
            user.ProjectsIds.ForEach(projectId =>
            {
                var project = _context.Db.Projects.SingleOrDefault(project => project.Id == projectId);
                _context.Db.Projects.Remove(project!);
            });

            _context.Db.Users.Remove(user);
            _context.Save();
            return NoContent();
        }
        catch (Exception e)
        {
            return Conflict($"Could not delete the item due to a conflict.\nError Message: {e.Message}");
        }
    }
}