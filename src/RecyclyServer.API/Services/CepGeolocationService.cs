using RecyclyServer.API.Infrastructure;
using System.Globalization;
using System.Text.Json;

namespace RecyclyServer.API.Services;

public class CepGeolocationService
{
    private readonly HttpClient _httpClient;

    public CepGeolocationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("RecyclyServerApp");
    }

    public async Task<(string address, double lat, double lng)> GetLocationFromCep(string cep)
    {
        var viaCepResponse = await _httpClient.GetStringAsync(
            $"https://viacep.com.br/ws/{cep}/json/");

        var viaCepData = JsonSerializer.Deserialize<ViaCepResponse>(viaCepResponse);

        if (viaCepData == null || viaCepData.erro)
            throw new System.Exception("CEP inválido.");

        var fullAddress =
            $"{viaCepData.logradouro}, {viaCepData.localidade}, {viaCepData.uf}, Brasil";

        var geoResponse = await _httpClient.GetStringAsync(
            $"https://nominatim.openstreetmap.org/search?q={fullAddress}&format=json");

        var geoData = JsonSerializer.Deserialize<List<NominatimResponse>>(geoResponse);

        if (geoData == null || !geoData.Any())
            throw new System.Exception("Não foi possível obter coordenadas.");

        var location = geoData.First();

        return (
            fullAddress,
            double.Parse(location.lat, CultureInfo.InvariantCulture),
            double.Parse(location.lon, CultureInfo.InvariantCulture)
        );
    }
}