namespace TechWiz.Errors
{
    public class InternalServerError : BaseError
    {
        public InternalServerError() : base("InternalServerError", "Erro interno do servidor"){}
    }

    public class InvalidFieldError : BaseError
    {
        public InvalidFieldError(string field) : base($"Invalid{field}", $"O campo {field} é inválido"){}
    }

    public class NotFoundError : BaseError
    {
        public NotFoundError(string resource) : base($"{resource}NotFound", $"{resource} não foi encontrado"){}
    }

    public class BadRequestBodyError : BaseError
    {
        public BadRequestBodyError() : base("BaseRequestBodyError", "Corpo da solicitação inválido") {}
    }
}