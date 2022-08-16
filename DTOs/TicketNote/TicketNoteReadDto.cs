namespace Infera_WebApi.DTOs.TicketNote
{
    public class TicketNoteReadDto
    {
        public int Id { get; set; }   
        public int TicketId { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
