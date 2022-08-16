using System;
using System.Collections.Generic;
using AutoMapper;
using Infera_WebApi.Context;
using Infera_WebApi.DTOs.Case;
using Infera_WebApi.Requests.Case;
using Microsoft.EntityFrameworkCore;

namespace Infera_WebApi.Repositories.Case
{
    public class CaseRepository : ICaseRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;

        public CaseRepository(SqlServerDbContext context, IMapper mapper)
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

            Models.Case @case = _context.Cases.Where(u => u.Id == Id).Include(x => x.Tickets).ThenInclude(y => y.TicketNotes).FirstOrDefault();

            if (@case == null)
                throw new KeyNotFoundException(nameof(Id));

            _context.Cases.Remove(@case);
            SaveChanges();
            return true;
        }
        public IEnumerable<CaseReadDto> GetAll(CaseGetAllRequest caseGetAllRequest)
        {
            var cases = _context.Cases.AsQueryable();

            if (caseGetAllRequest.Name != null)
                cases = cases.Where(ca => ca.Name.StartsWith(caseGetAllRequest.Name.Trim()));

            if (caseGetAllRequest.Code != null)
                cases = cases.Where(c => c.Code.StartsWith(caseGetAllRequest.Code.Trim()));
            caseGetAllRequest.TotalRecords = cases.Count();

            int Offset = (caseGetAllRequest.PageNumber - 1) * caseGetAllRequest.PageSize;
            int Limit = caseGetAllRequest.PageSize;

            var result = cases.OrderBy(c => c.Id)
                .Skip(Offset > 0 ? Offset : 0)
                .Take(Limit)
                .ToList();

            return _mapper.Map<IEnumerable<CaseReadDto>>(result);
        }
        public CaseReadDto GetById(int id)
        {
            return _mapper.Map<CaseReadDto>(_context.Cases.FirstOrDefault(c => c.Id == id));
        }
        public CaseReadDto Post(CasePostRequest casePostRequest)
        {
            if (casePostRequest == null)
            {
                throw new ArgumentNullException(nameof(casePostRequest));
            }

            Models.Case cases = _mapper.Map<Models.Case>(casePostRequest);
            _context.Cases.Add(cases);
            SaveChanges();
            return _mapper.Map<CaseReadDto>(cases);
        }
        public bool Update(int Id, CaseUpdateRequest caseUpdateRequest)
        {
            if (caseUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(CaseUpdateRequest));
                return false;
            }
            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
                return false;
            }
            Models.Case @case = _context.Cases.FirstOrDefault(c => c.Id == Id);

            if (@case == null)
            {
                throw new KeyNotFoundException(nameof(Id));
                return false;
            }
            if (caseUpdateRequest.Name != null) @case.Name = caseUpdateRequest.Name;
            if (caseUpdateRequest.Code != null) @case.Code = caseUpdateRequest.Code;
            _context.Entry(@case).State = EntityState.Modified;
            SaveChanges();
            _mapper.Map(@case, caseUpdateRequest);
            return true;
        }
        private bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
