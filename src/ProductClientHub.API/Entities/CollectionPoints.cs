namespace RecyclyServer.API.Entities
{
    public class CollectionPoints
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Guid CooperativeId { get; set; }
    }
}
