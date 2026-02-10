namespace ProductClientHub.Exception.ExceptionsBase
{
    // por ser abstrata, não pode ser instanciada diretamente, forçando que as exceções sejam específicas e usem essa como modelo
    public abstract class ProductClientHubException : System.Exception //transforma classe em exceção personalizada
    {
        public ProductClientHubException(string errorMessage) : base(errorMessage)
        {
            
        }

        public abstract List<string> GetErros(); 

    }
}
