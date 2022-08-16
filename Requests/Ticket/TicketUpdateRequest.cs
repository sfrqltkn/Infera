namespace Infera_WebApi.Requests.Ticket
{
    public class TicketUpdateRequest
    {
        public string? Description { get; set; }
        public string? NotiferPersonFullName { get; set; }
        public string? NotiferPersonTel { get; set; }
        public string? RegistrarPersonTel { get; set; }
        public int? Status { get; set; }
        public int? CaseId { get; set; }
    }
}
