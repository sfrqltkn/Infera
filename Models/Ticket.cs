using Infera_WebApi.Models.Base;

namespace Infera_WebApi.Models
{
    public class Ticket : BaseModel
    {
        public String Description { get; set; }
        public DateTime DateOfStart { get; set; }
        public String NotiferPersonFullName { get; set; }
        public String NotiferPersonTel { get; set; }
        public String RegistrarPersonTel { get; set; }
        public int Status { get; set; }
        public int CaseId { get; set; }
        public Case Case { get; set; }
        public ICollection<TicketNote> TicketNotes { get; set; }
    }
}
