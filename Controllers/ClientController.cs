using cv_api.Db;
using cv_api.DTOs;
using cv_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace cv_api.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly JsonContext _context;

    public ClientController()
    {
        _context = new JsonContext();
    }

    [HttpGet]
    public IActionResult GetAllClients()
    {
        return Ok(_context.Db.Clients);
    }

    [HttpGet("{id}")]
    public IActionResult GetClientById(int id)
    {
        var client = _context.Db.Clients.SingleOrDefault(client => client.Id == id);
        if (client == null) return NotFound();
        return Ok(client);
    }

    [HttpPost]
    public IActionResult AddClient([FromBody] ClientPostDto clientPostDto)
    {
        try
        {
            var id = 0;
            if (_context.Db.Clients.Count != 0)
                id = _context.Db.Clients[^1].Id + 1;

            var client = clientPostDto.ToClient(id);

            var user = _context.Db.Users.SingleOrDefault(u => u.Id == client.UserId);
            if (user == null) return NotFound();

            user.ClientsIds.Add(id);
            _context.Db.Clients.Add(client);
            _context.Save();

            var result = GetClientById(id) as OkObjectResult;
            return CreatedAtAction(nameof(GetClientById), new { id }, result?.Value);
        }
        catch (Exception e)
        {
            return Conflict($"Could not add the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateClient(int id, [FromBody] ClientPutDto clientPutDto)
    {
        var client = _context.Db.Clients.SingleOrDefault(client => client.Id == id);
        if (client == null) return NotFound();
        try
        {
            client.Name = clientPutDto.Name;
            client.Avatar = clientPutDto.Avatar;
            _context.Save();
            return Ok(client);
        }
        catch (Exception e)
        {
            return Conflict($"Could not update the item due to a conflict\nError Message: {e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveClient(int id)
    {
        var client = _context.Db.Clients.SingleOrDefault(client => client.Id == id);
        if (client == null) return NotFound();
        try
        {
            var user = _context.Db.Users.SingleOrDefault(user => user.Id == client.UserId)!;
            user.ClientsIds.Remove(client.Id);
            _context.Db.Clients.Remove(client);
            _context.Save();
            return NoContent();
        }
        catch (Exception e)
        {
            return Conflict($"Could not delete the item due to a conflict.\nError Message: {e.Message}");
        }
    }
}