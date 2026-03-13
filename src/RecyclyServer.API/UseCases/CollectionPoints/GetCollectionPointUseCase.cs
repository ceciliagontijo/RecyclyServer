using Azure.Core;
using RecyclyServer.API.Entities;
using RecyclyServer.API.UseCases.Materials.Register;
using RecyclyServer.Communication.Requets;
using RecyclyServer.Communication.Responses;
using RecyclyServer.Exception.ExceptionsBase;
using RecyclyServer.API.Infrastructure;
using RecyclyServerCommunication.Responses;

namespace RecyclyServer.API.UseCases.CollectionPoints
{
    public class GetCollectionPointUseCase
    {
        public ResponseAllCollectionPoint Execute(Guid materialId)
        {           

            var dbContext = new RecyclyServerDbContext();

            Validate(dbContext, materialId);


            var points = dbContext.CollectionPoints.ToList(); 


            return new ResponseAllCollectionPoint
            {
                CollectionPoints = points.Select(points => new ResponseCollectionPoints // seleciona retorno do tipo ResponseShortCLientJson
                {
                    I = points.Id,
                    Name = points.Name,
                    Latitude = points.Latitude,
                    Longitude = points.Longitude,
                }).ToList()
            };
        }

        private void Validate(RecyclyServerDbContext dbContext, Guid materialId)
        {
            var materialExist = dbContext.CollectionPointMaterials.Any(material => material.Id == materialId);
            if (materialExist == false)
                throw new NotFoundException("Client not found");

        }
    }
}
