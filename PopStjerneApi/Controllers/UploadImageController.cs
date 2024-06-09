using Microsoft.AspNetCore.Mvc;

namespace PopStjerneApi.Controllers;

[ApiController]
[Route("[controller]")]

public class UploadImageController : ControllerBase
{
    private readonly IWebHostEnvironment hosting;

    public UploadImageController(IWebHostEnvironment _hosting)
    {
        hosting = _hosting;
    }

    [HttpPost]
    public async Task<IActionResult> SaveImage(IFormFile file)
    {
        try
        {
            string wwwrootPath = hosting.WebRootPath;
            string absolutePath = Path.Combine($"{wwwrootPath}/images/artists/{file.FileName}");

            using(var fileStream = new FileStream(absolutePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }
}
