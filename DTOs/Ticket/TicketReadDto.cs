using Infera_WebApi.Models;
namespace Infera_WebApi.DTOs.Ticket
{
    public class TicketReadDto
    {   
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateOfStart { get; set; }
        public string? NotiferPersonFullName { get; set; }
        public string? NotiferPersonTel { get; set; }
        public string? RegistrarPersonTel { get; set; }
        public int Status { get; set; }
        public int CaseId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        }
}
