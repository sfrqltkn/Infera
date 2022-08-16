using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.UserRole
{
    public class UserRoleUpdateRequest : BaseRequest
    {
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
    }
}
