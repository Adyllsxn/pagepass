namespace PagePass.Api.Domain.Models
{
    public class ApiException
    {
        public string StatusCode { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Details { get; set; } = null!;
        public ApiException(string statuscode, string message, string details)
        {
            StatusCode = statuscode;
            Message = message;
            Details = details;
        }
    }
}