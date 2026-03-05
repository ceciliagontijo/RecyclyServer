using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecyclyServer.API.UseCases.Clients.Login;
using RecyclyServer.API.UseCases.Clients.Register;
using RecyclyServer.Communication.Requets;
using RecyclyServer.Communication.Responses;
using RecyclyServer.Exception.ExceptionsBase;
using System.Net;
namespace RecyclyServer.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
       
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]

        public IActionResult Register([FromBody] RequestClientJson request)
        
        {
            try
            {
               
                var useCase = new RegisterClientUseCase();
          
                var response = useCase.Execute(request);

                return Created(string.Empty, response); 
            }
            catch (RecyclyServerException ex)
            {
                var errors = ex.GetErros();
      
                return BadRequest(new ResponseErrorMessagesJson(errors));
            }
            catch
            {
             
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson("UNKNOWN ERROR"));
            }
        }

        [HttpPost("login")]

        [ProducesResponseType(typeof(ResponseClientJson), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]

        public IActionResult Login([FromBody] RequestLogin request)
        {

            try
            {
                var useCase = new LoginUseCase();

                var response = useCase.Execute(request);

                return Ok(response);
            }
            catch (RecyclyServerException ex)
            {
                var errors = ex.GetErros();

                return BadRequest(new ResponseErrorMessagesJson(errors));
            }
        }

    }
}
