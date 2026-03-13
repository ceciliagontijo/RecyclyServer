namespace RecyclyServer.Communication.Responses
{
    public class ResponseErrorMessagesJson
        // classe que devolve mensagens de erro em formato json
    {

        public List<string> Errors { get; private set;  } 
        // privte set: a lista so pode ser alterada dentro da própria classe
        public ResponseErrorMessagesJson(string message)
        //obriga a ter pelo menos uma mensagem de erro sempre que a classe for instanciada
        {
            Errors = [message]; //adiciona a mensagem recebida na lista de erros
        }

        public ResponseErrorMessagesJson(List<string> messages)
        {
            Errors = messages;
        }
    }
}
