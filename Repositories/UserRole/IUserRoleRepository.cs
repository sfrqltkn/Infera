using Infera_WebApi.DTOs.UserRole;
using Infera_WebApi.Requests.UserRole;

namespace Infera_WebApi.Repositories.UserRole
{
    public interface IUserRoleRepository
    {
        public IEnumerable<UserRoleReadingDto> GetAll(UserRoleGetAllRequest userroleGetAllRequest);
        public UserRoleReadDto Post(UserRolePostRequest userrolePostRequest);
        public bool Delete(UserRoleDeleteRequest userroleDeleteRequest);
    }
}
