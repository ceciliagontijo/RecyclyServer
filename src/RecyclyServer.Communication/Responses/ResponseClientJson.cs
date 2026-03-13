namespace RecyclyServer.Communication.Responses
{
    public class ResponseClientJson
    {

        public Guid Id { get; set; } //valor gerado pela propria API (por ser Guid)
        public string Name { get; set; } = string.Empty;
    }
}
