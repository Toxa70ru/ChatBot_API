using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Buffers.Text;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ChatBotContext _context;
        public ImageController(ChatBotContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] List<IFormFile> files,string groupName)
        {
            if (files == null || files.Count == 0) 
            {
                return BadRequest("Invalid file");
            }
            try 
            {
                var imageGroup = new ImageModel
                {
                    Filename = groupName,
                    Data =  new List<byte[]>()
                };

                foreach (var file in files) 
                {
                    using (var memoryStream = new MemoryStream()) 
                    {
                        await file.CopyToAsync(memoryStream);
                        byte[] data = memoryStream.ToArray();
                        imageGroup.Data.Add(data);
                    }
                }
                _context.ImageModel.Add(imageGroup);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,$"Failed to upload image:{ex.Message}");
            }


            /*_context.Image.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetImage), new { id = model.Id }, model);*/

        }

        [HttpGet("{id}")]
        public ActionResult<ImageModel> GetImage(long id)
        {
            var image = _context.ImageModel.Find(id);

            if (image == null)
            {
                return NotFound();
            }
            return image;
        }
    }
}
