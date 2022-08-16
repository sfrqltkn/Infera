using System.Collections;
using Infera_WebApi.Context;
using Infera_WebApi.DTOs.User;
using Infera_WebApi.Requests.User;
using Infera_WebApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infera_WebApi.Repositories.User
{
    public class UserRepository:IUserRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<UserReadDto> GetAll(UserGetAllRequest userGetAllRequest)
        {
            var users = _context.Users.AsQueryable();

            if (userGetAllRequest.Name != null)
                users=users.Where(x=>x.Name.StartsWith(userGetAllRequest.Name.Trim()));

            if (userGetAllRequest.Email != null)
                users = users.Where(x => x.Email.StartsWith(userGetAllRequest.Email.Trim()));

            if (userGetAllRequest.Surname != null)
                users = users.Where(x => x.Surname.StartsWith(userGetAllRequest.Surname.Trim()));

            userGetAllRequest.TotalRecords=users.Count();

            int Offset = (userGetAllRequest.PageNumber - 1) * userGetAllRequest.PageSize;
            int Limit = userGetAllRequest.PageSize;

            var result = users.OrderBy(u => u.Id)
                .Skip(Offset>0?Offset:0)
                .Take(Limit)
                .ToList();

            return _mapper.Map<IEnumerable<UserReadDto>>(result);
        }

        public UserReadDto GetById(int Id)
        {
            return _mapper.Map<UserReadDto>(_context.Users.FirstOrDefault(u => u.Id == Id));
        }

        public UserReadDto Post(UserPostRequest userPostRequest)
        {
            if (userPostRequest==null)
            {
                throw new ArgumentNullException(nameof(userPostRequest));
            }
            
            Models.User user = _mapper.Map<Models.User>(userPostRequest);
            //şifrelemek için kullanılır
            user.Password = BCrypt.Net.BCrypt.HashPassword(userPostRequest.Password);
            _context.Users.Add(user);
            SaveChanges();
            return _mapper.Map<UserReadDto>(user);
        }

        public bool Update(int Id, UserUpdateRequest userUpdateRequest)
        {
            if (userUpdateRequest==null)
            {
                throw new ArgumentNullException(nameof(UserUpdateRequest));
                return false;
            }

            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
                return false;
            }

            Models.User user = _context.Users.FirstOrDefault(u => u.Id == Id);

            if (user==null)
            {
                throw new KeyNotFoundException(nameof(Id));
                return false;
            }
            
            if(userUpdateRequest.Name!=null) user.Name = userUpdateRequest.Name;
            if(userUpdateRequest.Email!=null) user.Email = userUpdateRequest.Email;
            if(userUpdateRequest.Password!=null) user.Password = userUpdateRequest.Password;
            if(userUpdateRequest.Surname!=null) user.Surname = userUpdateRequest.Surname;
            _context.Entry(user).State = EntityState.Modified;
            SaveChanges();
            _mapper.Map(user, userUpdateRequest);
            return true;
        }

        public bool Delete(int Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            
            Models.User user = _context.Users.FirstOrDefault(u => u.Id == Id);
            if (user == null)
                throw new KeyNotFoundException(nameof(Id));

            _context.Users.Remove(user);
            SaveChanges();
            return true;
        }
        private bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
}
    }
