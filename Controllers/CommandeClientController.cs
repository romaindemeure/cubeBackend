using Microsoft.AspNetCore.Mvc;
using cubeBackend.Models;
using Microsoft.EntityFrameworkCore;
namespace cubeBackend.Controllers;

[ApiController]
[Route("api/CommandeClient")]
public class CommandeClientController : ControllerBase
{
    private readonly ILogger<CommandeClientController> _logger;
    private readonly cubeSQLContext _context;

    public CommandeClientController(ILogger<CommandeClientController> logger, cubeSQLContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET ALL USERS
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommandeClient>>> GetCommandeClients()
    {
        return await _context.CommandeClients.ToListAsync();
    }

    // GET USER BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<CommandeClient>> GetCommandeClient(int id)
    {
        var CommandeClient = await _context.CommandeClients.FindAsync(id);
        if (CommandeClient == null)
        {
            return NotFound();
        }

        return CommandeClient;
    }

    // CREATE USER
    [HttpPost]
    public async Task<ActionResult<CommandeClient>> PostCommandeClient(CommandeClient commandeclient)
    {
        _context.CommandeClients.Add(commandeclient);
        await _context.SaveChangesAsync();

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(GetCommandeClient), new { id = commandeclient.Id }, commandeclient);
    }

    // UPDATE USER BY ID
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCommandeClient(int id, CommandeClient commandeclient)
    {
        Console.WriteLine(commandeclient.Id);
        if (id != commandeclient.Id)
        {
            return BadRequest();
        }

        _context.Entry(commandeclient).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CommandeClientExist(id))
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
    public async Task<IActionResult> DeleteCommandeClient(int id)
    {
        var deleteCommandeClient = await _context.CommandeClients.FindAsync(id);
        if (deleteCommandeClient == null)
        {
            return NotFound();
        }

        _context.CommandeClients.Remove(deleteCommandeClient);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // CHECK IF USER EXIST
    private bool CommandeClientExist(int id)
    {
        return _context.CommandeClients.Any(e => e.Id == id);
    }
}
