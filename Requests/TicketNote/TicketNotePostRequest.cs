using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.TicketNote
{
    public class TicketNotePostRequest : BaseRequest
    {
        public int TicketId { get; set; }
        public string Note { get; set; }
    }
}
