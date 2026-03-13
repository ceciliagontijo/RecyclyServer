namespace RecyclyServerCommunication.Requets
{
    public class RequestCollectionPoints
    {
        public string Name { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;

        public List<Guid> MaterialsIds { get; set; } = new();

    }
}
