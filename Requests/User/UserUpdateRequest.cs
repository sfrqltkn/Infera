using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.User
{
    public class UserUpdateRequest:BaseRequest
    {
        public String? Name { get; set; }
        public String? Surname { get; set; }
        public String? Email { get; set; }
        public String? Password { get; set; }
    }
}
