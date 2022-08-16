namespace Infera_WebApi.DTOs.User
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
