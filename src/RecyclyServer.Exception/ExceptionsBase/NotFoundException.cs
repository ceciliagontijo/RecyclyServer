using System.Net;

namespace RecyclyServer.Exception.ExceptionsBase
{
    public class NotFoundException : RecyclyServerExceptions
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {

        }
        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
