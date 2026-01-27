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
        //indica os possíveis tipos de resposta da API
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)] 
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]

        public IActionResult Register([FromBody] RequestClientJson request)
        //request recebe dados (no formato determinado na classe RequestClientJson)
        {
            try
            {
                //cria um objeto da classe RegisterClientUseCase (que registra o cliente)
                var useCase = new RegisterClientUseCase();

                // chama o método Execute com os dados recebidos no request
                // o objeto useCase recebe o request (temporariamente para executar a lógica) e retorna um response
                var response = useCase.Execute(request);

                return Created(string.Empty, response); //função existente dentro da classe ControllerBase
            }
            catch (ArgumentException ex)
            {
                //bad request = erro de requisição
                //instanciando um objeto da classe ResponseErrorMessagesJson para retornar mensagens de erro
                return BadRequest(new ResponseErrorMessagesJson(ex.Message));
            }
            catch
            {
                //quando o erro é desconhecido (não é um erro de argumento como acima)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson("UNKNOWN ERROR"));
            }
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
