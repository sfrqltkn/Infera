using Infera_WebApi.DTOs.Case;
using Infera_WebApi.Repositories.Case;
using Infera_WebApi.Requests.Case;
using Infera_WebApi.Responses.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infera_WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController:Controller
    {
        private readonly ICaseRepository _caseRepository;
        public CaseController(ICaseRepository caseRepository)
        {
            _caseRepository=caseRepository;
        }
        [HttpGet]
        public PagedResponse<CaseReadDto> Get([FromBody] CaseGetAllRequest caseGetAllRequest)
        {
            IEnumerable<CaseReadDto> data = _caseRepository.GetAll(caseGetAllRequest);
            return new PagedResponse<CaseReadDto>(data.ToList(), caseGetAllRequest.PageNumber, caseGetAllRequest.PageSize, caseGetAllRequest.TotalRecords);
        }
        [HttpGet("{id}")]
        public CaseReadDto Get(int id)
        {
            return _caseRepository.GetById(id);
        }

        // POST api/<RolesController>
        [HttpPost]
        public CaseReadDto Post([FromBody] CasePostRequest casePostRequest)
        {
            return _caseRepository.Post(casePostRequest);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CaseUpdateRequest caseUpdateRequest)
        {
            if (_caseRepository.Update(id, caseUpdateRequest))
            {
                return Ok();
            }
            return NotFound();
        }
        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_caseRepository.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
