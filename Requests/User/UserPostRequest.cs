using System.ComponentModel.DataAnnotations;
using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.User
{
    public class UserPostRequest:BaseRequest
    {
        public String? Name { get; set; }
        public String? Surname { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
