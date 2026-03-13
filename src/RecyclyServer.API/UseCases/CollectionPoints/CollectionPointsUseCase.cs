using Microsoft.EntityFrameworkCore;
using RecyclyServer.API.Entities;
using RecyclyServer.API.Services;
using RecyclyServerCommunication.Requets;
using RecyclyServerCommunication.Responses;

namespace RecyclyServer.API.UseCases.CollectionPoints
{
    public class CollectionPointsUseCase
    {
        private readonly CepGeolocationService _geoService;

        public CollectionPointsUseCase(CepGeolocationService geoService)
        {
            _geoService = geoService;
        }

        public async Task<ResponseCollectionPoints> Execute(RequestCollectionPoints request)
        {
            

            var (address, lat, lng) = await _geoService.GetLocationFromCep(request.CEP);

            var entity = new CollectionPoint
            {
                Name = request.Name,
                CEP = request.CEP,
                Address = address,
                Latitude = lat,
                Longitude = lng
            };

            var dbContext = new Infrastructure.RecyclyServerDbContext();

            dbContext.CollectionPoints.Add(entity);  

            dbContext.SaveChanges();

            foreach (var materialId in request.MaterialsIds)
            {
                dbContext.CollectionPointMaterials.Add(new CollectionPointMaterial
                {
                    CollectionPointId = entity.Id,
                    MaterialId = materialId
                });
            }

            dbContext.SaveChanges();

            return new ResponseCollectionPoints
            {
                Id = entity.Id,
                Name = entity.Name,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude
            };
        }
    }
}

