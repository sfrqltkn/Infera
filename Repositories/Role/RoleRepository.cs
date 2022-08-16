using AutoMapper;
using Infera_WebApi.Context;
using Infera_WebApi.DTOs.Role;
using Infera_WebApi.Requests.Role;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infera_WebApi.Repositories.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Delete(int Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            Models.Role role = _context.Roles.FirstOrDefault(u => u.Id == Id);
            if (role == null)
                throw new KeyNotFoundException(nameof(Id));

            _context.Roles.Remove(role);
            SaveChanges();
            return true;
        }

        public IEnumerable<RoleReadDto> GetAll(RoleGetAllRequest roleGetAllRequest)
        {
            var roles = _context.Roles.AsQueryable();

            if (roleGetAllRequest.Name != null)
                roles = roles.Where(x => x.Name.StartsWith(roleGetAllRequest.Name.Trim()));

            if (roleGetAllRequest.Description != null)
                roles = roles.Where(x => x.Description.StartsWith(roleGetAllRequest.Description.Trim()));



            roleGetAllRequest.TotalRecords = roles.Count();

            int Offset = (roleGetAllRequest.PageNumber - 1) * roleGetAllRequest.PageSize;
            int Limit = roleGetAllRequest.PageSize;

            var result = roles.OrderBy(u => u.Id)
                .Skip(Offset > 0 ? Offset : 0)
                .Take(Limit)
                .ToList();

            return _mapper.Map<IEnumerable<RoleReadDto>>(result);
        }

        public RoleReadDto GetById(int Id)
        {
            return _mapper.Map<RoleReadDto>(_context.Roles.FirstOrDefault(u => u.Id == Id));
        }

        public RoleReadDto Post(RolePostRequest rolePostRequest)
        {
            if (rolePostRequest == null)
            {
                throw new ArgumentNullException(nameof(rolePostRequest));
            }

            Models.Role roles = _mapper.Map<Models.Role>(rolePostRequest);
            _context.Roles.Add(roles);
            SaveChanges();
            return _mapper.Map<RoleReadDto>(roles);
        }

        public bool Update(int Id, RoleUpdateRequest roleUpdateRequest)
        {
            if (roleUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(RoleUpdateRequest));
                return false;
            }

            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
                return false;
            }

            Models.Role roles = _context.Roles.FirstOrDefault(u => u.Id == Id);

            if (roles == null)
            {
                throw new KeyNotFoundException(nameof(Id));
                return false;
            }

            if (roleUpdateRequest.Name != null) roles.Name = roleUpdateRequest.Name;
            if (roleUpdateRequest.Description != null) roles.Description = roleUpdateRequest.Description;
            _context.Entry(roles).State = EntityState.Modified;
            SaveChanges();
            _mapper.Map(roles, roleUpdateRequest);
            return true;
        }
        private bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
