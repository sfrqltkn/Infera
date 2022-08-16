using Infera_WebApi.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Infera_WebApi.Models.Base
{
    public class BaseModel:ISoftDelete
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
