using FluentValidation;
using ProductClientHub.Communication.Requets;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientValidator : AbstractValidator<RequestClientJson> //biblioteca FluentValidation
    {
        public RegisterClientValidator() // construtor
        {
            // indica que estou criando uma regra para Name do objeto client (nao pode ser vazio)
            RuleFor(client => client.Name).NotEmpty().WithMessage("The name cannot be empty"); 
          
            RuleFor(client => client.Email).EmailAddress().WithMessage("This email is not valid"); 
        }
    }
}
