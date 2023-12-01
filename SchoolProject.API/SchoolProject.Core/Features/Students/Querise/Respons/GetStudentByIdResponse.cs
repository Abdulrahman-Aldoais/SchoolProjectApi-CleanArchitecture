namespace SchoolProject.Core.Features.Students.Querise.Respons
{
    public class GetStudentByIdResponse
    {

        public Guid StudID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Guid DID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? DepartmentName { get; set; }
    }
}
