using Infera_WebApi.DTOs.User;
using Infera_WebApi.Repositories.User;
using Infera_WebApi.Requests.User;
using Infera_WebApi.Responses.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infera_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        
        public UsersController(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }


        // GET: api/<UsersController>
        [HttpGet] [Authorize]
        public PagedResponse<UserReadDto> Get([FromBody] UserGetAllRequest userGetAllRequest)
        {
            IEnumerable<UserReadDto> data = _userRepository.GetAll(userGetAllRequest);
            return new PagedResponse<UserReadDto>(data.ToList(),userGetAllRequest.PageNumber,userGetAllRequest.PageSize,userGetAllRequest.TotalRecords);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")] [Authorize]
        public UserReadDto Get(int id)
        {
            return _userRepository.GetById(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public UserReadDto Post([FromBody] UserPostRequest userPostRequest)
        {
            return _userRepository.Post(userPostRequest);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")] [Authorize]
        public IActionResult Put(int id, [FromBody] UserUpdateRequest userUpdateRequest)
        {
            if (_userRepository.Update(id,userUpdateRequest))
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")] [Authorize]
        public IActionResult Delete(int id)
        {
            if (_userRepository.Delete(id))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
