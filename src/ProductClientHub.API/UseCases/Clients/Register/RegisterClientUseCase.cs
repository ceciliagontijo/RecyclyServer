using ProductClientHub.Communication.Requets;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exception.ExceptionsBase;

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
            var result = validator.Validate(request); //FluentValidation

            if (result.IsValid == false)
            {
                // após dar erro no result, o FluentValidation gera uma lista de objetos de erro (contendo nao so a string de erro)
                // o select pega só a string (errormessage) de cada objeto de erro da lista e transforma em uma nova lista só de string de erros
                var errors = result.Errors.Select(erro => erro.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }

            return new ResponseClientJson();
        }
    }
}
