namespace DziennikAdministratora.Api.ViewModels
{
    public class JwtModel
    {
        public string Token {get; set;}
        public long ExpiryMinutes {get; set;}
    }
}