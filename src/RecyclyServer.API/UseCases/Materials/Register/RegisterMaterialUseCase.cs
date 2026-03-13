using FluentValidation;
using RecyclyServer.Communication.Requets;
using RecyclyServer.Communication.Responses;
using RecyclyServer.Exception.ExceptionsBase;
using RecyclyServer.API.Entities;
using RecyclyServer.API.Infrastructure;

namespace RecyclyServer.API.UseCases.Materials.Register
{
    public class RegisterMaterialUseCase
    {    
        public ResponseMaterial Execute(RequestMaterialJson request)
        {

            Validate(request);

            var dbContext = new RecyclyServerDbContext();


            var entity = new Material
            {
                Name = request.Name,               
            };

            dbContext.Materials.Add(entity);

            dbContext.SaveChanges();


            return new ResponseMaterial
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        private void Validate(RequestMaterialJson request)
        {       
            var validator = new RequestMaterialValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(erro => erro.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
