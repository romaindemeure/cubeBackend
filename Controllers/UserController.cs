using Microsoft.AspNetCore.Mvc;
using cubeBackend.Models;
using Microsoft.EntityFrameworkCore;
namespace cubeBackend.Controllers;

[ApiController]
[Route("api/Utilisateur")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly cubeSQLContext _context;

    public UserController(ILogger<UserController> logger, cubeSQLContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET ALL USERS
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUsers()
    {
        return await _context.Utilisateurs.ToListAsync();
    }

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

    // UPDATE USER BY ID
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, Utilisateur user)
    {
        Console.WriteLine(user.Id);
        if (id != user.Id)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExist(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
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

    // CHECK IF USER EXIST
    private bool UserExist(int id)
    {
        return _context.Utilisateurs.Any(e => e.Id == id);
    }
}
