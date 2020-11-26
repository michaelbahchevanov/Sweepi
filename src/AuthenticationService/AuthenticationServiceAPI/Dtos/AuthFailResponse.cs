using System.Collections.Generic;

namespace Sweepi.AuthenticationServiceAPI.Dtos
{
    public class AuthFailResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
