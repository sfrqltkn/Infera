using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.Role
{
    public class RoleUpdateRequest : BaseRequest
    {
        public String? Name { get; set; }
        public String? Description { get; set; }
    }
}
