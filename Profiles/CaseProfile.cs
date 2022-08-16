using AutoMapper;
using Infera_WebApi.DTOs.Case;
using Infera_WebApi.Models;
using Infera_WebApi.Requests.Case;

namespace Infera_WebApi.Profiles
{
    public class CaseProfile : Profile
    {
        public CaseProfile()
        {
            CreateMap<Case, CaseReadDto>();
            CreateMap<CaseReadDto, Case>();
            CreateMap<CasePostRequest, Case>();
            CreateMap<Case, CasePostRequest>();
            CreateMap<Case, CaseUpdateRequest>();
        }
    }
}
