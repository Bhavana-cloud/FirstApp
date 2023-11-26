using FirstApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private IApiLogger _logger;
        public PersonController(IApiLogger logger)
        {
             _logger= logger;
        }
        [HttpGet("/api/people")]
        public IActionResult GetPeople()
        {
            _logger.Log("start logging getpeople()!");
            _logger.Log("GetPeople() api call successful");
            return Ok(PersonOperation.GetPeople());
        }
        [HttpPost("api/create")]
        public IActionResult CreatePerson([FromForm] Person p)
        {
            PersonOperation.CreateNew(p);
            _logger.Log("CreatePerson() api call successful");
            return Created($"created person with aadhar{p.Aadhar}successfully",p);
        }
        [HttpPut("/api/update/{pAadhar}")]
        public IActionResult UpdatePerson([FromRoute] string pAadhar,[FromBody] Person updatedperson) {
            try
            {
                PersonOperation.Update(pAadhar, updatedperson);
                _logger.Log("UpdatePerson() api call successful");
                return Ok("update successful");
            }
            catch(Exception ex)
            {
                _logger.Log("UpdatePerson() api call not successful");
                return NotFound(ex.Message);

            }
            
        }
        [HttpDelete("/api/delete")] //Eg : https://localhost/7021/api/delete?pAadhar=34gjh6678{query string}
        public IActionResult DeletePerson([FromQuery] string pAadhar)
        {
            try
            {
                PersonOperation.Delete(pAadhar);
                _logger.Log("DeletePerson() api call successful");
                return Ok("deletion successful");
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}
