using FluentValidation;
using RecyclyServer.Communication.Requets;
namespace RecyclyServer.API.UseCases.Materials.Register

{
    public class RequestMaterialValidator : AbstractValidator<RequestMaterialJson>
    {
        public RequestMaterialValidator() 
        {
            RuleFor(material => material.Name).NotEmpty().WithMessage("Material name is required.");           
        }
    }
}
