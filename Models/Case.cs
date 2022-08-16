using Infera_WebApi.Models.Base;

namespace Infera_WebApi.Models
{
    public class Case : BaseModel
    {
        public String? Name { get; set; }
        public int SolutionTime { get; set; }
        public int InterventionTime { get; set; }
        public String Code { get; set; }
        public int ParentId { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
