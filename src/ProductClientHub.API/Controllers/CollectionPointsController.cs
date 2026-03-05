using Microsoft.AspNetCore.Mvc;
using RecyclyServer.API.Services;
using RecyclyServer.API.UseCases.Clients.Register;
using RecyclyServer.API.UseCases.CollectionPoints;
using RecyclyServer.Communication.Requets;
using RecyclyServer.Communication.Responses;
using RecyclyServer.Exception.ExceptionsBase;
using RecyclyServerCommunication.Requets;

namespace RecyclyServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionPointsController : ControllerBase
    {
       
            [HttpPost("register_point")] 
            
            [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
            [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]

            public async Task<IActionResult> Register([FromBody] RequestCollectionPoints request)        
            {
                try
                {
                    var geoService = new CepGeolocationService(new HttpClient());

                    var useCase = new CollectionPointsUseCase(geoService);
                    
                    var response =  await useCase.Execute(request);

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
        }
    }

