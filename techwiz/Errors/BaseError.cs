using System.Text.Json.Serialization;

namespace TechWiz.Errors
{
    public class BaseError
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        public BaseError(string error, string message)
        {
            Error = error;
            Message = message;
        }
    }
}