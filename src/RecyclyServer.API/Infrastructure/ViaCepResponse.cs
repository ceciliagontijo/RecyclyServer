namespace RecyclyServer.API.Infrastructure
{
    public class ViaCepResponse
    {
        public string logradouro { get; set; } = string.Empty;
        public string localidade { get; set; } = string.Empty;
        public string uf { get; set; } = string.Empty;
        public bool erro { get; set; }
    }
}
