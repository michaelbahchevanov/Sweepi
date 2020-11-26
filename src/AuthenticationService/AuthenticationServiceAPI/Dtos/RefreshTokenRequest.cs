namespace Sweepi.AuthenticationServiceAPI.Dtos
{
    public class RefreshTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
