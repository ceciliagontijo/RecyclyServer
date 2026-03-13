using System.Net;

namespace RecyclyServer.Exception.ExceptionsBase
{
    // por ser abstrata, não pode ser instanciada diretamente, forçando que as exceções sejam específicas e usem essa como modelo
    public abstract class RecyclyServerExceptions : System.Exception //transforma classe em exceção personalizada
    {
        public RecyclyServerExceptions(string errorMessage) : base(errorMessage)
        {
            
        }

        public abstract List<string> GetErrors();

        public abstract HttpStatusCode GetHttpStatusCode();

    }
}
