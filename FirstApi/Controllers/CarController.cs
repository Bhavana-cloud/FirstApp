using FirstApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private Car _car;
        private IApiLogger _logger;
        private CarAccess _access;


        public CarController(Car c,IApiLogger logger,CarAccess ia)
        {
            _car = c;
            _logger = logger;
            _logger.Log("CarController instance is created");

            _access = ia;
            _logger = logger;
            _logger.Log("CarController instance created");

             
        }
        [HttpGet("/drive")]
        public IActionResult Drive()
        {
            _logger.Log("Driving() api called successfully");
            return Ok("driving at 100kmph");
        }
        [HttpGet("/accessories")]
        public IActionResult Favorite()
        {
            _logger.Log("accessories logged");
            return Ok("favorite accessories");
        }
    }
}
