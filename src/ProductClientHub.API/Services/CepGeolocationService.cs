using RecyclyServer.API.Infrastructure;
using System.Net.Http;
using System.Text.Json;

namespace RecyclyServer.API.Services;
public class CepGeolocationService
{
    private readonly HttpClient _httpClient;

    public CepGeolocationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(string address, double lat, double lng)> GetLocationFromCep(string cep)
    {
        // 1️⃣ Busca endereço no ViaCEP
        var viaCepResponse = await _httpClient.GetStringAsync(
            $"https://viacep.com.br/ws/{cep}/json/");

        var viaCepData = JsonSerializer.Deserialize<ViaCepResponse>(viaCepResponse);

        var fullAddress =
            $"{viaCepData.logradouro}, {viaCepData.localidade}, {viaCepData.uf}, Brasil";

        // 2️⃣ Busca coordenadas no OpenStreetMap
        var geoResponse = await _httpClient.GetStringAsync(
            $"https://nominatim.openstreetmap.org/search?q={fullAddress}&format=json");

        var geoData = JsonSerializer.Deserialize<List<NominatimResponse>>(geoResponse);

        var location = geoData.First();

        return (fullAddress,
                double.Parse(location.lat),
                double.Parse(location.lon));
    }
}