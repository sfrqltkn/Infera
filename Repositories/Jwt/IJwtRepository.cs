using Infera_WebApi.DTOs.User;
using Infera_WebApi.Requests.Jwt;

namespace Infera_WebApi.Repositories.Jwt
{
    public interface IJwtRepository
    {
        public UserReadDto GetUser(String email,String password);
        public int GetByName();
        public String CreateToken(int id);
    }
}
