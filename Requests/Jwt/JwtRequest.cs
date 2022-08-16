using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.Jwt
{
    public class JwtRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
