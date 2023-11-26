using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Mapping.StudentMapp
{
    public partial class StudentProfileMapping
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetStudentByIdResponse>()
                           // This fills the DepartmentName present in GetStudentListResponse with the data from virtual Department
                           .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DNameAr))
                           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
