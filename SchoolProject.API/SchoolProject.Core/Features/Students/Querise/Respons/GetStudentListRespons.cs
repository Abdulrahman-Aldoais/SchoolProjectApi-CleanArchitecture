using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Core.Features.Students.Querise.Respons
{
    public class GetStudentListRespons
    {
        [Key]
        public Guid StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? DepartmentName { get; set; }
    }
}
