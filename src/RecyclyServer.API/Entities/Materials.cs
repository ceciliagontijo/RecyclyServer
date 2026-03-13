namespace RecyclyServer.API.Entities
{
    public class Materials
    {
        public string Name { get; set; } = string.Empty;

        public Guid CollectionPointId { get; set; }
    }
}
