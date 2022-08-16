using Infera_WebApi.DTOs.User;

namespace Infera_WebApi.DTOs.Role
{
    public class RoleReadDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public List<UserReadDto> Userlist { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
