using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.User
{
    public class UserGetAllRequest:BaseRequest
    {
        public String? Name { get; set; }
        public String? Surname { get; set; }
        public String? Email { get; set; }
    }
}
