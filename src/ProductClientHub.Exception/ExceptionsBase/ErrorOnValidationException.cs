namespace ProductClientHub.Exception.ExceptionsBase
{
    
    public class ErrorOnValidationException : ProductClientHubException
    {
        // readonly permite que a lista seja alterada apenas no construtor
        // _erros vai guardar a lista de erros dessa exceção personalizada (ErrorOnValidationException)
        private readonly List<string> _errors;
        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages; // salva na classe(exceção) a lista de erros passada no construtor
        }

        // implementa o método da classe pai e recebe como a exceção retorna os erros para a API(lista)
        public override List<string> GetErros()
        {
            return _errors;
        }
    }
}
