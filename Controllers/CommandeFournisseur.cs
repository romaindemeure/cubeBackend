using Microsoft.AspNetCore.Mvc;
using cubeBackend.Models;
using Microsoft.EntityFrameworkCore;
namespace cubeBackend.Controllers;

[ApiController]
[Route("api/CommandeFournisseur")]
public class CommandeFournisseurController : ControllerBase
{
    private readonly ILogger<CommandeFournisseurController> _logger;
    private readonly cubeSQLContext _context;

    public CommandeFournisseurController(ILogger<CommandeFournisseurController> logger, cubeSQLContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET ALL COMMANDES FOURNISSEURS
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommandeFournisseur>>> GetCommandeFournisseurs()
    {
        return await _context.CommandeFournisseurs.ToListAsync();
    }

    // GET COMMANDE FOURNISSEUR BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<CommandeFournisseur>> GetCommandeFournisseur(int id)
    {
        var CommandeFournisseur = await _context.CommandeFournisseurs.FindAsync(id);
        if (CommandeFournisseur == null)
        {
            return NotFound();
        }

        return CommandeFournisseur;
    }

    // CREATE COMMANDE FOURNISSEUR
    [HttpPost]
    public async Task<ActionResult<CommandeFournisseur>> PostCommandeFournisseur(CommandeFournisseur commandefournisseur)
    {
        _context.CommandeFournisseurs.Add(commandefournisseur);
        await _context.SaveChangesAsync();

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(GetCommandeFournisseur), new { id = commandefournisseur.Id }, commandefournisseur);
    }

    // UPDATE COMMANDE FOURNISSEUR BY ID
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCommandeFournisseur(int id, CommandeFournisseur commandefournisseur)
    {
        Console.WriteLine(commandefournisseur.Id);
        if (id != commandefournisseur.Id)
        {
            return BadRequest();
        }

        _context.Entry(commandefournisseur).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CommandeFournisseurExist(id))
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

    // DELETE COMMANDE FOURNISSEUR BY ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommandeFournisseur(int id)
    {
        var DeleteCommandeFournisseur = await _context.CommandeFournisseurs.FindAsync(id);
        if (DeleteCommandeFournisseur == null)
        {
            return NotFound();
        }

        _context.CommandeFournisseurs.Remove(DeleteCommandeFournisseur);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // CHECK IF COMMANDE FOURNISSEUR EXIST
    private bool CommandeFournisseurExist(int id)
    {
        return _context.CommandeFournisseurs.Any(e => e.Id == id);
    }
}
