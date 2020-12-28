namespace Sweepi.AuthenticationServiceAPI.Dtos
{
    public class AuthSuccessResponse
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
