using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecyclyServer.API.UseCases.Materials.Register;
using RecyclyServer.Communication.Requets;
using RecyclyServer.Communication.Responses;

namespace RecyclyServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        [HttpPost]       
        [ProducesResponseType(typeof(ResponseMaterial), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]       
        public IActionResult Register([FromBody] RequestMaterialJson request)

        {
            var useCase = new RegisterMaterialUseCase();

            var response = useCase.Execute(request); //clientId sera passado por parametro (usuario digita)

            return Created(string.Empty, response);

        }
    }
}