using Infera_WebApi.Requests.Base;
using System.ComponentModel.DataAnnotations;

namespace Infera_WebApi.Requests.Ticket
{
    public class TicketPostRequest : BaseRequest
    {
        public String Description { get; set; }
        public DateTime DateOfStart { get; set; }
        public String? NotiferPersonFullName { get; set; }
        public String? NotiferPersonTel { get; set; }
        public String? RegistrarPersonTel { get; set; }
        public int Status { get; set; }
        public int CaseId { get; set; }

    }
}

