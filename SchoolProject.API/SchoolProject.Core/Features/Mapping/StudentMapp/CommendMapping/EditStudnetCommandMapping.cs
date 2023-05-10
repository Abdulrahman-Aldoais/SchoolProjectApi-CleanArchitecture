using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Mapping.StudentMapp
{
    public partial class StudentProfileMapping
    {
        public void EditStudnetCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                           // This fills the DepartmentName present in GetStudentListResponse with the data from virtual Department
                           .ForMember(dest => dest.DID, pot => pot.MapFrom(src => src.DepartmentId))
                           .ForMember(dest => dest.StudID, pot => pot.MapFrom(src => src.Id));
        }
    }
}
