using Microsoft.AspNetCore.Mvc;
using cubeBackend.Models;
using Microsoft.EntityFrameworkCore;
namespace cubeBackend.Controllers;

[ApiController]
[Route("api/Fournisseur")]
public class FournisseurController : ControllerBase
{
    private readonly ILogger<FournisseurController> _logger;
    private readonly cubeSQLContext _context;

    public FournisseurController(ILogger<FournisseurController> logger, cubeSQLContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET ALL FOURNISSEURS
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fournisseur>>> GetFournisseurs()
    {
        return await _context.Fournisseurs.ToListAsync();
    }

    // GET FOURNISSEUR BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Fournisseur>> GetFournisseur(int id)
    {
        var GetFournisseur = await _context.Fournisseurs.FindAsync(id);
        if (GetFournisseur == null)
        {
            return NotFound();
        }

        return GetFournisseur;
    }

    // CREATE FOURNISSEUR
    [HttpPost]
    public async Task<ActionResult<Fournisseur>> PostFournisseur(Fournisseur fournisseur)
    {
        _context.Fournisseurs.Add(fournisseur);
        await _context.SaveChangesAsync();

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(GetFournisseur), new { id = fournisseur.Id }, fournisseur);
    }

    // UPDATE FOURNISSEUR BY ID
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFournisseur(int id, Fournisseur fournisseur)
    {
        if (id != fournisseur.Id)
        {
            return BadRequest();
        }

        _context.Entry(fournisseur).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FournisseurExist(id))
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

    // DELETE FOURNISSEUR BY ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFournisseur(int id)
    {
        var DeleteFournisseur = await _context.Fournisseurs.FindAsync(id);
        if (DeleteFournisseur == null)
        {
            return NotFound();
        }

        _context.Fournisseurs.Remove(DeleteFournisseur);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // CHECK IF FOURNISSEUR EXIST
    private bool FournisseurExist(int id)
    {
        return _context.Fournisseurs.Any(e => e.Id == id);
    }
}
