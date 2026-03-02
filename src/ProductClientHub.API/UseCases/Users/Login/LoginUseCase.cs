using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Requets;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exception.ExceptionsBase;
using BCrypt.Net;


namespace ProductClientHub.API.UseCases.Clients.Login
{
    public class LoginUseCase
    {
        public ResponseClientJson Execute(RequestLogin request)
        {
            var dbContext = new RecyclyServerDbContext();

            var client = dbContext.Clients.FirstOrDefault(c => c.CPF == request.CPF);

            if (client == null)
            {
                throw new ErrorOnValidationException(new List<string> {"Cooperative was not found"});
            }

            //criptografia da senha 
            var passwordIsValid = BCrypt.Net.BCrypt.Verify(request.Password,client.Password);

            if(!passwordIsValid)
            {
                throw new ErrorOnValidationException(new List<string> {"Invalid password"});
            }

            return new ResponseClientJson
            {
                Id = client.Id,
                Name = client.Name
            };

        }
    }
}
