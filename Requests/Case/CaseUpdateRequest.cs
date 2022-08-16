using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.Case
{
    public class CaseUpdateRequest:BaseRequest
    {
        public String? Name { get; set; }
        public int? SolutionTime { get; set; }
        public int? InterventionTime { get; set; }
        public String Code { get; set; }
        public int ParentId { get; set; }
    }
}
