using cv_api.Db;
using cv_api.DTOs;
using cv_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace cv_api.Controllers;

[Route("api/certificates")]
[ApiController]
public class CertificateController : ControllerBase
{
    private readonly JsonContext _context;

    public CertificateController()
    {
        _context = new JsonContext();
    }

    [HttpGet]
    public IActionResult GetAllCertificates()
    {
        return Ok(_context.Db.Certificates);
    }

    [HttpGet("{id}")]
    public IActionResult GetCertificateById(int id)
    {
        var certificate = _context.Db.Certificates.SingleOrDefault(certificate => certificate.Id == id);
        if (certificate == null) return NotFound();
        return Ok(certificate);
    }

    [HttpPost]
    public IActionResult AddCertificate([FromBody] CertificatePostDto certificatePostDto)
    {
        try
        {
            var id = 0;
            if (_context.Db.Certificates.Count != 0)
                id = _context.Db.Certificates[^1].Id + 1;

            var certificate = certificatePostDto.ToCertificate(id);

            var user = _context.Db.Users.SingleOrDefault(u => u.Id == certificate.UserId);
            if (user == null) return NotFound();

            user.CertificatesIds.Add(id);
            _context.Db.Certificates.Add(certificate);
            _context.Save();

            var result = GetCertificateById(id) as OkObjectResult;
            return CreatedAtAction(nameof(GetCertificateById), new { id }, result?.Value);
        }
        catch (Exception e)
        {
            return Conflict($"Could not add the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCertificate(int id, [FromBody] CertificatePutDto certificatePutDto)
    {
        var certificate = _context.Db.Certificates.SingleOrDefault(certificate => certificate.Id == id);
        if (certificate == null) return NotFound();
        try
        {
            certificate.Course = certificatePutDto.Course;
            certificate.Code = certificatePutDto.Code;
            certificate.Date = certificatePutDto.Date;
            certificate.Image = certificatePutDto.Image;
            _context.Save();
            return Ok(certificate);
        }
        catch (Exception e)
        {
            return Conflict($"Could not update the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveCertificate(int id)
    {
        var certificate = _context.Db.Certificates.SingleOrDefault(certificate => certificate.Id == id);
        if (certificate == null) return NotFound();
        try
        {
            var user = _context.Db.Users.SingleOrDefault(user => user.Id == certificate.UserId)!;
            user.CertificatesIds.Remove(certificate.Id);
            _context.Db.Certificates.Remove(certificate);
            _context.Save();
            return NoContent();
        }
        catch (Exception e)
        {
            return Conflict($"Could not delete the item due to a conflict.\nError Message: {e.Message}");
        }
    }
}