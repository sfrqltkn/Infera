using AutoMapper;
using Infera_WebApi.DTOs.User;
using Infera_WebApi.Models;
using Infera_WebApi.Requests.User;

namespace Infera_WebApi.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserReadDto, User>();
            CreateMap<UserPostRequest,User>();
            CreateMap<User, UserPostRequest>();
            CreateMap<User, UserUpdateRequest>();
        }
    }
}
