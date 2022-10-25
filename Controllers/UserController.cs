using Microsoft.AspNetCore.Mvc;
using cubeBackend.Models;

namespace cubeBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    private readonly ILogger<UserController> _logger;
    private readonly cubeSQLContext _context;

    public UserController(ILogger<UserController> logger, cubeSQLContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET ALL USERS
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Utilisateur>>> GetTodoItems()
    // {
    //     return await _context.Utilisateurs.ToListAsync();
    // }

    // GET USER BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Utilisateur>> GetUser(int id)
    {
        var getUser = await _context.Utilisateurs.FindAsync(id);
        if (getUser == null)
        {
            return NotFound();
        }

        return getUser;
    }

    // CREATE USER
    [HttpPost]
    public async Task<ActionResult<Utilisateur>> PostUser(Utilisateur user)
    {
        _context.Utilisateurs.Add(user);
        await _context.SaveChangesAsync();

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // DELETE USER BY ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleteUser = await _context.Utilisateurs.FindAsync(id);
        if (deleteUser == null)
        {
            return NotFound();
        }

        _context.Utilisateurs.Remove(deleteUser);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateTime.Now.AddDays(index),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
}
