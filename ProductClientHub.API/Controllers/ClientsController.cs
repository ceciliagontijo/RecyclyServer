using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requets;
using ProductClientHub.Communication.Responses;
// classe controller: mostra o que a API vai receber e retornar em cada endpoint (rotas)
namespace ProductClientHub.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)] // o que vai ser retornado
        public IActionResult Register([FromBody] RequestClientJson request) //recebe dados do corpo da classe RequestClientJson
        {
            //cria um objeto da classe RegisterClientUseCase (que registra o cliente)
            //é necessário um objeto do tipo RegisterClientUseCase para chamar o método Execute
            var useCase = new RegisterClientUseCase();

            // chama o método Execute com os dados recebidos no request
            // o objeto useCase recebe o request (temporariamente para executar a lógica) e retorna um response
            var response = useCase.Execute(request); 

            return Created(string.Empty, response); //função existente dentro da classe ControllerBase
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok(); 
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(); 
        }

        [HttpGet] //não pode ter dois métodos GET iguais - (by-id)
        [Route("{id}")] //outra forma de definir a rota
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok(); 
        }
    }
}
