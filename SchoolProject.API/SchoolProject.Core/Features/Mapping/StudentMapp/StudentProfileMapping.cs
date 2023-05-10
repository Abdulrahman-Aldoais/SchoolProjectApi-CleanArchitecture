using AutoMapper;

namespace SchoolProject.Core.Features.Mapping.StudentMapp
{
    public partial class StudentProfileMapping : Profile
    {
        public StudentProfileMapping()
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
            AddStudentCommandMapping();
            EditStudnetCommandMapping();


        }
    }
}
