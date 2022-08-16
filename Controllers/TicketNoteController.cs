using Infera_WebApi.DTOs.TicketNote;
using Infera_WebApi.Repositories;
using Infera_WebApi.Repositories.TicketNote;
using Infera_WebApi.Requests.TicketNote;
using Infera_WebApi.Responses.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infera_WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketNoteController : Controller
    {
        private readonly ITicketNoteRepository _ticketNoteRepository;
        public TicketNoteController(ITicketNoteRepository ticketNoteRepository)
        {
            _ticketNoteRepository = ticketNoteRepository;
        }
        [HttpGet]

        public PagedResponse<TicketNoteReadDto> Get([FromBody] TicketNoteGetAllRequest ticketNoteGetAllRequest)
        {
            //PagedResponse sınıfını kullanarak RoleReadDto türündeki verileri çeker
            IEnumerable<TicketNoteReadDto> data = _ticketNoteRepository.GetAll(ticketNoteGetAllRequest);
            return new PagedResponse<TicketNoteReadDto>(data.ToList(), ticketNoteGetAllRequest.PageNumber, ticketNoteGetAllRequest.PageSize, ticketNoteGetAllRequest.TotalRecords);
        }
        [HttpGet("{id}")]
        public TicketNoteReadDto Get(int id)
        {
            return _ticketNoteRepository.GetById(id);
        }
        [HttpPost]
        public TicketNoteReadDto Post([FromBody] TicketNotePostRequest ticketNotePostRequest)
        {
            return _ticketNoteRepository.Post(ticketNotePostRequest);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TicketNoteUpdateRequest ticketNoteUpdateRequest)
        {
            if (_ticketNoteRepository.Update(id, ticketNoteUpdateRequest))
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_ticketNoteRepository.Delete(id))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
