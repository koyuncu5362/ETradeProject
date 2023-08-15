using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
        IProductImageService _productImageService;

        public FileUploadController(IWebHostEnvironment webHostEnvironment,IProductImageService productImageService)
        {
            _productImageService = productImageService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("addwithimage")]
        public IActionResult UploadFiles(List<IFormFile> files, int productId)
        {
            string directory = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/Uploads/Images");
            try
            {
                foreach (var file in files)
                {
                    string filepath = Path.Combine(directory, file.FileName);
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        file.CopyTo(stream);

                        using (var memoryStream = new MemoryStream())
                        {
                            stream.Seek(0, SeekOrigin.Begin);
                            stream.CopyTo(memoryStream);

                            var image = new ProductImageModel
                            {
                                Name = file.FileName,
                                ContentType = file.ContentType,
                                Data = memoryStream.ToArray(),
                                ProductId = productId
                            };

                             _productImageService.Add(image);
                        }
                    }
                }
                return Ok("Success");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
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
