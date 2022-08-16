using Infera_WebApi.Requests.Base;
namespace Infera_WebApi.Requests.TicketNote
{
    public class TicketNoteGetAllRequest : BaseRequest
    {
        public String? Note { get; set; }
    }
}
