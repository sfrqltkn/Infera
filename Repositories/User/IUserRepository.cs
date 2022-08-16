using Infera_WebApi.DTOs.User;
using Infera_WebApi.Requests.User;

namespace Infera_WebApi.Repositories.User
{
    public interface IUserRepository
    {
        public IEnumerable<UserReadDto> GetAll(UserGetAllRequest userGetAllRequest);
        public UserReadDto GetById(int Id);
        public UserReadDto Post(UserPostRequest userPostRequest);
        public bool Update(int Id, UserUpdateRequest userUpdateRequest);
        public bool Delete(int Id);
    }
}
