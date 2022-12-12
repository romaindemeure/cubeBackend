using Microsoft.AspNetCore.Mvc;
using cubeBackend.Models;
using Microsoft.EntityFrameworkCore;
namespace cubeBackend.Controllers;

[ApiController]
[Route("api/Article")]
public class ArticleController : ControllerBase
{
    private readonly ILogger<ArticleController> _logger;
    private readonly cubeSQLContext _context;

    public ArticleController(ILogger<ArticleController> logger, cubeSQLContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET ALL ARTICLES
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
    {
        return await _context.Articles.ToListAsync();
    }

    // GET ARTICLE BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticle(int id)
    {
        var GetArticle = await _context.Articles.FindAsync(id);
        if (GetArticle == null)
        {
            return NotFound();
        }

        return GetArticle;
    }

    // CREATE ARTICLE
    [HttpPost]
    public async Task<ActionResult<Article>> PostArticle(Article article)
    {
        _context.Articles.Add(article);
        await _context.SaveChangesAsync();

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article);
    }

    // UPDATE ARTICLE BY ID
    [HttpPut("{id}")]
    public async Task<IActionResult> PutArticle(int id, Article article)
    {
        Console.WriteLine(article.Id);
        if (id != article.Id)
        {
            return BadRequest();
        }

        _context.Entry(article).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ArticleExist(id))
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

    // DELETE ARTICLE BY ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle(int id)
    {
        var deleteArticle = await _context.Articles.FindAsync(id);
        if (deleteArticle == null)
        {
            return NotFound();
        }

        _context.Articles.Remove(deleteArticle);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // CHECK IF ARTICLE EXIST
    private bool ArticleExist(int id)
    {
        return _context.Articles.Any(e => e.Id == id);
    }
}
