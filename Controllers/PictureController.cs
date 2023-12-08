using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/picture")]
public class PictureController : ControllerBase
{
    private readonly ApiContext _context;
    public PictureController(ApiContext context)
    {
        _context = context;
    }

    // GET: api/picture
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Picture>>> Getpictures()
    {
        var pictures = _context.Pictures;
        return await pictures.ToListAsync();
    }

    // GET: api/picture/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Picture>> Getpicture(int id)
    {
        var picture = await _context.Pictures.SingleOrDefaultAsync(g => g.Id == id);
        if (picture == null)
            return NotFound();
        return picture;
    }

    // POST: api/picture
    [HttpPost]
    public async Task<ActionResult<Picture>> Postpicture(Picture picture)
    {
        _context.Pictures.Add(picture);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Getpicture), new { id = picture.Id }, picture);
    }

    // PUT: api/picture/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Putpicture(int id, Picture picture)
    {
        if (id != picture.Id)
            return BadRequest();
        _context.Entry(picture).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Pictures.Any(u => u.Id == id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    // DELETE: api/picture/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletepictureItem(int id)
    {
        var picture = await _context.Pictures.FindAsync(id);
        if (picture == null)
            return NotFound();
        _context.Pictures.Remove(picture);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}