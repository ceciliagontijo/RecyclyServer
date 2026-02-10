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
                // errors vai receber as mensagens de erro
                // result.Errors é uma coleção de erros, (falha => falha.ErrorMessage) vai extrair a mensagem específica de cada erro
                var errors = result.Errors.Select(falha => falha.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }

            return new ResponseClientJson();
        }
    }
}
