using Infera_WebApi.Requests.Base;
namespace Infera_WebApi.Requests.Role
{
    public class RoleGetAllRequest : BaseRequest
    {
        public String? Name { get; set; }
        public String? Description { get; set; }
    }
}
