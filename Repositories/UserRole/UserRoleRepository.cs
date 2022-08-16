using AutoMapper;
using Infera_WebApi.Context;
using Infera_WebApi.DTOs.UserRole;
using Infera_WebApi.Requests.UserRole;
using Microsoft.EntityFrameworkCore;

namespace Infera_WebApi.Repositories.UserRole
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;

        public UserRoleRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Delete(UserRoleDeleteRequest userroleDeleteRequest)
        {
            if (userroleDeleteRequest == null)
            {
                throw new ArgumentNullException(nameof(userroleDeleteRequest));
                return false;
            }

            Models.UserRole userrole = _context.UserRoles.FirstOrDefault(u => u.UserId == userroleDeleteRequest.UserId && u.RoleId == userroleDeleteRequest.RoleId);


            if (userrole == null)
                throw new KeyNotFoundException(nameof(userroleDeleteRequest.UserId));

            _context.UserRoles.Remove(userrole);
            SaveChanges();
            return true;
        }
        public class CategoryDto
        {
            public string RoleName { get; set; }
            public string UserName { get; set; }
            public DateTime CreatedAt { get; set; }
        }
  
        public IEnumerable<UserRoleReadingDto> GetAll(UserRoleGetAllRequest userroleGetAllRequest)
        {
            var userroles = _context.UserRoles.Include(x=>x.User).Include(x=>x.Role).AsQueryable();
            if (userroleGetAllRequest.RoleId != null)
                userroles = userroles.Where(x => x.RoleId == userroleGetAllRequest.RoleId);
            if (userroleGetAllRequest.UserId != null)
                userroles = userroles.Where(x => x.UserId == userroleGetAllRequest.UserId);
            userroleGetAllRequest.TotalRecords = userroles.Count();
            int Offset = (userroleGetAllRequest.PageNumber - 1) * userroleGetAllRequest.PageSize;
            int Limit = userroleGetAllRequest.PageSize;

 
            List<UserRoleReadingDto> list = new List<UserRoleReadingDto>();     
            foreach (var x in userroles)
            {
                list.Add(new UserRoleReadingDto
                {
                    RoleName = x.Role.Name,
                    UserName = x.User.Name,
                    CreatedAt = x.CreatedAt
                });
            }
         
            var result = list.OrderBy(u => u.UserName)
                .Skip(Offset > 0 ? Offset : 0)
                .Take(Limit)
                .ToList();
            return _mapper.Map<IEnumerable<UserRoleReadingDto>>(result);
        }

        public IEnumerable<UserRoleReadingDto> GetAll2(UserRoleGetAllRequest userroleGetAllRequest)
        {
            var userroles = _context.UserRoles.AsQueryable();
            if (userroleGetAllRequest.RoleId != null)
                userroles = userroles.Where(x => x.RoleId == userroleGetAllRequest.RoleId);
            if (userroleGetAllRequest.UserId != null)
                userroles = userroles.Where(x => x.UserId == userroleGetAllRequest.UserId);
            userroleGetAllRequest.TotalRecords = userroles.Count();
            int Offset = (userroleGetAllRequest.PageNumber - 1) * userroleGetAllRequest.PageSize;
            int Limit = userroleGetAllRequest.PageSize;


            var result = userroles.OrderBy(u => u.UserId)
             .Skip(Offset > 0 ? Offset : 0)
             .Take(Limit)
             .ToList();

            return _mapper.Map<IEnumerable<UserRoleReadingDto>>(result);
        }
        public UserRoleReadDto Post(UserRolePostRequest userrolePostRequest)
        {
            if (userrolePostRequest == null)
            {
                throw new ArgumentNullException(nameof(userrolePostRequest));
            }
            Models.UserRole userRole = _mapper.Map<Models.UserRole>(userrolePostRequest);
            _context.UserRoles.Add(userRole);
            SaveChanges();
            return _mapper.Map<UserRoleReadDto>(userRole);
        }
        private bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}