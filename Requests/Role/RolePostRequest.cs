using Infera_WebApi.Requests.Base;
using System.ComponentModel.DataAnnotations;

namespace Infera_WebApi.Requests.Role
{
    public class RolePostRequest : BaseRequest
    {
        [Required]
        public String Name { get; set; }
        [Required]     
        public String Description { get; set; }

    }
}
