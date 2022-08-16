namespace Infera_WebApi.DTOs.Case
{
    public class CaseReadDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int SolutionTime { get; set; }
        public int InterventionTime { get; set; }
        public String Code { get; set; }
        public int ParentId { get; set; }
        public CaseReadDto Parent  { get; set; }
    }
}
