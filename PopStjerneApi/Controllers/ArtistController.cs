using Microsoft.AspNetCore.Mvc;
using PopStjerneApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PopStjerneApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ArtistController : ControllerBase
{
    private readonly ArtistContext context;

    public ArtistController(ArtistContext _context)
    {
        context = _context;
    }

    // Method for getting all artists
    [HttpGet]
    public async Task<ActionResult<List<Artist>>> Get()
    {
        try
        {
            List<Artist> artists = await context.Artist.ToListAsync();

            return Ok(artists);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // Method for getting artist by id
    [HttpGet("{id}")]
    public async Task<ActionResult<Artist>> GetById(int id)
    {
        try{
            Artist? artist = await context.Artist.FindAsync(id);

            if (artist != null)
            {
                return Ok(artist);
            }
            else
            {
                return NotFound();
            }
        } catch
        {
            return StatusCode(500);
        }
    }

    // Method for getting artist by name
    [HttpGet]
    [Route("[action]")]
    public async Task<ActionResult<Artist>> GetArtistByName(string artistName)
    {
        try{
            
            Artist? artistByName = await context.Artist.SingleOrDefaultAsync(artist => artist.ArtistName.ToLower() == artistName.ToLower());
            
            if (artistByName != null)
            {
                return artistByName;
            }
            else
            {
                return NotFound();
            }
        } catch
        {
            return StatusCode(500);
        }
    }

    // Method for posting an artist
    // Utilizing the [FromBody] annotation in post and put methods to make sure the object in parameter is coming from the request body
    [HttpPost]
    public async Task<ActionResult<Artist>> PostArtist([FromBody] Artist a)
    {

        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState); // If model state is not valid, return status code 400 with validation error
        }

        try
        {
            context.Artist.Add(a);
            await context.SaveChangesAsync();

            return CreatedAtAction("Get", new {id = a.Id}, a);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // Method for altering an artist
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Artist alteredArtist)
    {

        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            context.Entry(alteredArtist).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }
         catch
        {
            return BadRequest();
        }
    }

    // Method for deleting an artist with a given id
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Artist? artistToDelete = await context.Artist.FindAsync(id);
            if (artistToDelete != null)
            {
                context.Artist.Remove(artistToDelete);
                await context.SaveChangesAsync();

                // Checking if all artists are deleted from table in db. If they are, then:
                if (!await context.Artist.AnyAsync())
                {
                    // Reset auto-increment to 1
                    await context.Database.ExecuteSqlRawAsync("DELETE FROM sqlite_sequence WHERE name = 'Artist';");
                }
                
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }
}