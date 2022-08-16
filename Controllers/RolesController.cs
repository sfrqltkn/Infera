using Infera_WebApi.DTOs.Role;
using Infera_WebApi.Repositories.Role;
using Infera_WebApi.Requests.Role;
using Infera_WebApi.Responses.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infera_WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        //Bu class IRoleRepository'deki değişkenleri okumak için oluşturulmuş
        //Kullanıcı bir parametre alıyor bu parametre IRoleRepository tipinde okunmasını sağlıyor
        {
            _roleRepository = roleRepository;
        }
        // GET: api/<RolesController>
        [HttpGet] 
        public PagedResponse<RoleReadDto> Get([FromBody] RoleGetAllRequest roleGetAllRequest)
        {
            //PagedResponse sınıfını kullanarak RoleReadDto türündeki verileri çeker
            IEnumerable<RoleReadDto> data = _roleRepository.GetAll(roleGetAllRequest);
            return new PagedResponse<RoleReadDto>(data.ToList(), roleGetAllRequest.PageNumber, roleGetAllRequest.PageSize, roleGetAllRequest.TotalRecords);
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public RoleReadDto Get(int id)
        {
            return _roleRepository.GetById(id);
        }

        // POST api/<RolesController>
        [HttpPost]
        public RoleReadDto Post([FromBody] RolePostRequest rolePostRequest)
        {
            return _roleRepository.Post(rolePostRequest);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleUpdateRequest roleUpdateRequest)
        {
            if (_roleRepository.Update(id, roleUpdateRequest))
            {
                return Ok();
            }
            return NotFound();
        }
        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_roleRepository.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
