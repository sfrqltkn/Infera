using Infera_WebApi.DTOs.Case;
using Infera_WebApi.Requests.Case;

namespace Infera_WebApi.Repositories.Case
{
    public interface ICaseRepository
    {
        public IEnumerable<CaseReadDto> GetAll(CaseGetAllRequest caseGetAllRequest);
        public CaseReadDto GetById(int id);
        public CaseReadDto Post(CasePostRequest casePostRequest);
        public bool Update(int Id, CaseUpdateRequest caseUpdateRequest);
        public bool Delete(int Id);
    }
}
