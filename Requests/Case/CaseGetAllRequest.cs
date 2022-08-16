using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.Case
{
    public class CaseGetAllRequest : BaseRequest
    {
        public String? Name { get; set; }
        public String? Code { get; set; }
    }
}
