using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        IFavouriteService _favouriteService;
        public FavouritesController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }
        [HttpPost("add")]
        public IActionResult Add(Favourite favourite)
        {
            var result = _favouriteService.Add(favourite);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Favourite favourite)
        {
            var result = _favouriteService.Delete(favourite);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll(string customerId)
        {
            var result = _favouriteService.GetAllFavourite(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyId")]
        public IActionResult GetById(int productId,string customerId)
        {
            var result = _favouriteService.GetById(productId,customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("deletebyId")]
        public IActionResult DeleteById(int productId, string customerId)
        {
            var result = _favouriteService.DeleteByCustomerIdAndProductId(productId, customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
