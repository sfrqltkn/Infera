using Infera_WebApi.DTOs.UserRole;
using Infera_WebApi.Models;
using Infera_WebApi.Repositories.UserRole;
using Infera_WebApi.Requests.UserRole;
using Infera_WebApi.Responses.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infera_WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly IUserRoleRepository _userroleRepository;

        public UserRoleController(IUserRoleRepository userroleRepository)
        {
            _userroleRepository = userroleRepository;
        }
        [HttpGet]

        public PagedResponse<UserRoleReadingDto> Get([FromBody] UserRoleGetAllRequest userroleGetAllRequest)
        {
            IEnumerable<UserRoleReadingDto> data = _userroleRepository.GetAll(userroleGetAllRequest);
            return new PagedResponse<UserRoleReadingDto>(data.ToList(),userroleGetAllRequest.PageNumber, userroleGetAllRequest.PageSize, userroleGetAllRequest.TotalRecords);
        }
      
        [HttpPost]
        public UserRoleReadDto Post([FromBody] UserRolePostRequest userrolePostRequest)
        {
            return _userroleRepository.Post(userrolePostRequest);
        }
      
        [HttpDelete]
        public IActionResult Delete([FromBody] UserRoleDeleteRequest userroleDeleteRequest)
        {
            if (_userroleRepository.Delete(userroleDeleteRequest))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}