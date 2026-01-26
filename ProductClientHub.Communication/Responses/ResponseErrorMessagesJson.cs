namespace ProductClientHub.Communication.Responses
{
    public class ResponseErrorMessagesJson
    {

        public List<string> Errors { get; set;  }

        public ResponseErrorMessagesJson(string message)
        {
            Errors = [message];
        }
    }
}
