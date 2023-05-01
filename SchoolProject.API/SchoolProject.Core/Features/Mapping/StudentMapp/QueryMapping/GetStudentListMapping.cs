using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Mapping.StudentMapp//this namespace is the same StudentProfileMapping partial
{
    public partial class StudentProfileMapping
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListRespons>()
                           // This fills the DepartmentName present in GetStudentListResponse with the data from virtual Department
                           .ForMember(dest => dest.DepartmentName, pot => pot.MapFrom(src => src.Department.DName));
        }
    }
}
