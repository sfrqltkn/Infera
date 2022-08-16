using AutoMapper;
using Infera_WebApi.DTOs.UserRole;
using Infera_WebApi.Models;
using Infera_WebApi.Requests.UserRole;

namespace Infera_WebApi.Profiles
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRole, UserRoleReadingDto>();
            CreateMap<UserRoleReadingDto, UserRole>();
            CreateMap<UserRole, UserRoleReadDto>();
            CreateMap<UserRoleReadDto, UserRole>();
            CreateMap<UserRole, UserRolePostRequest>();
            CreateMap<UserRole, UserRoleUpdateRequest>();
        }
    }
}
