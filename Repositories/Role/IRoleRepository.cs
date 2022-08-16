using Infera_WebApi.DTOs.Role;
using Infera_WebApi.Requests.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Infera_WebApi.Repositories.Role
{
    public interface IRoleRepository
    {
        public IEnumerable<RoleReadDto> GetAll(RoleGetAllRequest roleGetAllRequest); 
        //RoleReadDto tipinde gelen nesneleri tutar.
        public RoleReadDto GetById(int Id);
        public RoleReadDto Post(RolePostRequest rolePostRequest);
        public bool Update(int Id, RoleUpdateRequest roleUpdateRequest);
        public bool Delete(int Id);    
    }
}
