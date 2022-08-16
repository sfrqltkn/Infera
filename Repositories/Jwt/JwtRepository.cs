using AutoMapper;
using Infera_WebApi.Context;
using Infera_WebApi.DTOs.User;
using Infera_WebApi.Requests.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infera_WebApi.Repositories.Jwt
{
    public class JwtRepository : IJwtRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IConfiguration _configuration;

        public JwtRepository(SqlServerDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _configuration = config;
        }
        public UserReadDto GetUser(String email,String password)
        {
            Models.User user=_context.Users.Where(u=>u.Email.Equals(email)).FirstOrDefault();
            if(user== null)
                throw new ArgumentNullException(nameof(user));

            //kullanıcı tarafından girilen şifreyle veri tabanına kaydedilen şifreyi kontrol eder
            bool passVerify = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (passVerify == true)
                return _mapper.Map<UserReadDto>(user);

            return null;
        }
        public int GetByName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }

            return Convert.ToInt16(result);
        }
        public String CreateToken(int id)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(JwtRegisteredClaimNames.Name, id.ToString())
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);
            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
