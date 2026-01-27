using ProductClientHub.Communication.Requets;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.UseCases.Clients.Register
    // classe responsável por registrar um novo cliente no sistema
{
    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            // objeto criado vai receber as regras de validação ao entrar no construtor
            var validator = new RegisterClientValidator();

            // objeto validator (contém as regras) vai validar o request (dados recebidos)
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                throw new ArgumentException("ERROR IN RECEIVED DATA");
            }

            return new ResponseClientJson();
        }
    }
}
