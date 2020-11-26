using System;
using System.ComponentModel.DataAnnotations;

namespace Sweepi.AuthenticationServiceAPI.Models
{
    public class UserRegisterRequest
    {
        public Guid Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}