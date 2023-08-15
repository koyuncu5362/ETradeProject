using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EfImageDal _efImageDal;

        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("[action]")]
        public IActionResult UploadFiles(List<IFormFile> files)
        {
            string directory = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/Uploads/Images");
            EfImageDal efImage = new EfImageDal();

            foreach (var file in files)
            {
                string filepath = Path.Combine(directory, file.FileName);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    file.CopyTo(stream);

                    // FileStream'ı MemoryStream'a kopyalayarak içeriği alın
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.Seek(0, SeekOrigin.Begin);
                        stream.CopyTo(memoryStream);

                        var image = new ProductImageModel
                        {
                            Name = file.FileName,
                            ContentType = file.ContentType,
                            Data = memoryStream.ToArray()
                        };

                        efImage.Add(image);
                    }
                }
            }

            return Ok("Success");
        }
        [HttpGet("getall")]
        public IActionResult GetAllImages()
        {
            try
            {
                EfImageDal efImage = new EfImageDal();
                var images = efImage.GetAll(); // EfImageDal'dan GetAll metodu çağırılmalı

                return Ok(images);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: " + ex.Message);
            }
        }

    }
}
