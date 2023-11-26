namespace SchoolProject.Core.Features.Students.Querise.Respons
{
    public class GetStudentPaginatedListRespons
    {
        public Guid StudentID { get; set; }
        public string? StudentName { get; set; }
        public string? Address { get; set; }
        public string? DepartmerntName { get; set; }
        public GetStudentPaginatedListRespons(Guid studentID, string studentName, string address, string departmentName)
        {
            StudentID = studentID;
            StudentName = studentName;
            Address = address;
            DepartmerntName = departmentName;
        }


    }

}
