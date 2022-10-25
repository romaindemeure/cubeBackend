// using Microsoft.AspNetCore.Mvc;
// using cubeBackend.Models;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.EntityFrameworkCore;
// namespace cubeBackend.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class ProviderController : ControllerBase
// {
//     private readonly ILogger<ProviderController> _logger;
//     private readonly cubeSQLContext _context;

//     public ProviderController(ILogger<ProviderController> logger, cubeSQLContext context)
//     {
//         _logger = logger;
//         _context = context;
//     }

//     // GET ALL USERS
//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<Fournisseur>>> GetFournisseurs()
//     {
//         return await _context.Fournisseurs.ToListAsync();
//     }

//     // GET USER BY ID
//     [HttpGet("{id}")]
//     public async Task<ActionResult<Utilisateur>> GetFournisseur(int id)
//     {
//         var GetFournisseur = await _context.Fournisseurs.FindAsync(id);
//         if (GetFournisseur == null)
//         {
//             return NotFound();
//         }

//         return GetFournisseur;
//     }

//     // CREATE USER
//     [HttpPost]
//     public async Task<ActionResult<Utilisateur>> PostUser(Utilisateur user)
//     {
//         _context.Utilisateurs.Add(user);
//         await _context.SaveChangesAsync();

//         //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
//         return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
//     }

//     // UPDATE USER BY ID
//     [HttpPut("{id}")]
//     public async Task<IActionResult> PutUser(int id, Utilisateur user)
//     {
//         if (id != user.Id)
//         {
//             return BadRequest();
//         }

//         _context.Entry(user).State = EntityState.Modified;

//         try
//         {
//             await _context.SaveChangesAsync();
//         }
//         catch (DbUpdateConcurrencyException)
//         {
//             if (!UserExist(id))
//             {
//                 return NotFound();
//             }
//             else
//             {
//                 throw;
//             }
//         }

//         return NoContent();
//     }

//     // DELETE USER BY ID
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteUser(int id)
//     {
//         var deleteUser = await _context.Utilisateurs.FindAsync(id);
//         if (deleteUser == null)
//         {
//             return NotFound();
//         }

//         _context.Utilisateurs.Remove(deleteUser);
//         await _context.SaveChangesAsync();

//         return NoContent();
//     }

//     // CHECK IF USER EXIST
//     private bool UserExist(int id)
//     {
//         return _context.Utilisateurs.Any(e => e.Id == id);
//     }
// }
