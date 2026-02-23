namespace ProductClientHub.API.Entities
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid(); //um ID novo a cada instancia (cada cliente a ser registrado)

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}