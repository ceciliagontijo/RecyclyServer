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


            var pointIds = dbContext.CollectionPointMaterials //busca na tabela de relacionamento os Ids dos pontos de coleta
            .Where(x => x.MaterialId == materialId)
            .Select(x => x.CollectionPointId)
            .ToList();

            var points = dbContext.CollectionPoints // pega esses Ids e busca os pontos de coleta correspondentes
                .Where(p => pointIds.Contains(p.Id))
                .ToList();

            return new ResponseAllCollectionPoint
            {
                CollectionPoints = points.Select(point => new ResponseCollectionPoints 
                {
                    Id = point.Id,
                    Name = point.Name,
                    Latitude = point.Latitude,
                    Longitude = point.Longitude,
                }).ToList()
            };
        }

        private void Validate(RecyclyServerDbContext dbContext, Guid materialId)
        {
            var materialExist = dbContext.CollectionPointMaterials.Any(material => material.MaterialId == materialId);
            if (materialExist == false)
                throw new NotFoundException("Client not found");

        }
    }
}
