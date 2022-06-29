using Infera_WebApi.Models.Base;

namespace Infera_WebApi.Models
{
    public class User:BaseModel
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}
