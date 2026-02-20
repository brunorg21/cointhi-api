namespace Cointhi.Api.DTOs.Response
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public LoggedUserResponse User { get; set; }
    }
}
