using Infera_WebApi.Context;
using Infera_WebApi.Repositories.Jwt;
using Infera_WebApi.Requests.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Infera_WebApi.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class JwtController:Controller
    {
        private readonly SqlServerDbContext _context;
        private readonly IJwtRepository _jwtRepository;
        public JwtController(SqlServerDbContext context, IJwtRepository jwtRepository)
        { 
            _context = context;
            _jwtRepository = jwtRepository;
        }
        [HttpGet] [Authorize]
        public int Get()
        {
            return _jwtRepository.GetByName();

        }
        [HttpPost]
        public IActionResult Post(JwtRequest _userData)
        { 
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = _jwtRepository.GetUser(_userData.Password,_userData.Email);

                if (user != null)
                {
                    //create claims details based on the user information
                    return Ok(_jwtRepository.CreateToken(user.Id));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
