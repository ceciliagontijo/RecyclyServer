namespace RecyclyServer.Exception.ExceptionsBase
{
    // por ser abstrata, não pode ser instanciada diretamente, forçando que as exceções sejam específicas e usem essa como modelo
    public abstract class RecyclyServerException : System.Exception //transforma classe em exceção personalizada
    {
        public RecyclyServerException(string errorMessage) : base(errorMessage)
        {
            
        }

        public abstract List<string> GetErros(); 

    }
}
