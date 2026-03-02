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

            RuleFor(client => client.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one number");

            RuleFor(client => client.CPF)
                .Must(IsValidCpf)
                .WithMessage("CPF is invalid");
        }

        private bool IsValidCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
                return false;

            var numbers = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            // Primeiro dígito
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += numbers[i] * (10 - i);

            int result = sum % 11;
            int firstDigit = result < 2 ? 0 : 11 - result;

            if (numbers[9] != firstDigit)
                return false;

            // Segundo dígito
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += numbers[i] * (11 - i);

            result = sum % 11;
            int secondDigit = result < 2 ? 0 : 11 - result;

            return numbers[10] == secondDigit;
        }
    }
}
