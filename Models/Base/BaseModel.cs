using System.ComponentModel.DataAnnotations;

namespace Infera_WebApi.Models.Base
{
    public class BaseModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
