using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/fav")]
public class FavController : ControllerBase
{
    private readonly ApiContext _context;
    public FavController(ApiContext context)
    {
        _context = context;
    }

    // GET: api/fav
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fav>>> Getfavs()
    {
        var favs = _context.Favs;
        return await favs.ToListAsync();
    }

    // GET: api/fav/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Fav>> Getfav(int id)
    {
        var fav = await _context.Favs.SingleOrDefaultAsync(f => f.Id == id);
        if (fav == null)
            return NotFound();
        return fav;
    }

    // GET: api/fav/user/1
    [HttpGet("user/{id}")]
    public async Task<ActionResult<IEnumerable<Fav>>> GetfavGame(int id)
    {
        var favs = await _context.Favs.Where(f => f.Id_Game == id).ToListAsync();
        if (favs == null || !favs.Any())
            return NotFound();

        return favs;
    }

    // POST: api/fav
    [HttpPost]
    public async Task<ActionResult<Fav>> Postfav(Fav fav)
    {
        _context.Favs.Add(fav);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Getfav), new { id = fav.Id }, fav);
    }

    // PUT: api/fav/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Putfav(int id, Fav fav)
    {
        if (id != fav.Id)
            return BadRequest();
        _context.Entry(fav).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Favs.Any(f => f.Id == id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    // DELETE: api/fav/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletefavItem(int id)
    {
        var fav = await _context.Favs.FindAsync(id);
        if (fav == null)
            return NotFound();
        _context.Favs.Remove(fav);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}