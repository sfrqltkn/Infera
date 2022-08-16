using Infera_WebApi.DTOs.Ticket;
using Infera_WebApi.Repositories.Ticket;
using Infera_WebApi.Requests.Ticket;
using Infera_WebApi.Responses.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infera_WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketController(ITicketRepository roleRepository)
        //Bu class IRoleRepository'deki değişkenleri okumak için oluşturulmuş
        //Kullanıcı bir parametre alıyor bu parametre IRoleRepository tipinde okunmasını sağlıyor
        {
            _ticketRepository = roleRepository;
        }
        [HttpGet]
        public PagedResponse<TicketReadDto> Get([FromBody] TicketGetAllRequest ticketGetAllRequest)
        {
            //PagedResponse sınıfını kullanarak RoleReadDto türündeki verileri çeker
            IEnumerable<TicketReadDto> data = _ticketRepository.GetAll(ticketGetAllRequest);
            return new PagedResponse<TicketReadDto>(data.ToList(), ticketGetAllRequest.PageNumber, ticketGetAllRequest.PageSize, ticketGetAllRequest.TotalRecords);
        }
        [HttpGet("{id}")]
        public TicketReadDto Get(int id)
        {
            return _ticketRepository.GetById(id);
        }
        [HttpPost]
        public TicketReadDto Post([FromBody] TicketPostRequest ticketPostRequest)
        {
            return _ticketRepository.Post(ticketPostRequest);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TicketUpdateRequest ticketUpdateRequest)
        {
            if (_ticketRepository.Update(id, ticketUpdateRequest))
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_ticketRepository.Delete(id))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
