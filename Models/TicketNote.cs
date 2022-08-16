using Infera_WebApi.Models.Base;

namespace Infera_WebApi.Models
{
    public class TicketNote:BaseModel
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public String Note { get; set; }
    }
}
