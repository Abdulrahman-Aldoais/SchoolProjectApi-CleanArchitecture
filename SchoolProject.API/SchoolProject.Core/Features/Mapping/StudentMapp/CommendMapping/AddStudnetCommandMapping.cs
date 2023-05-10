using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Mapping.StudentMapp
{
    public partial class StudentProfileMapping 
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                           // This fills the DepartmentName present in GetStudentListResponse with the data from virtual Department
                           .ForMember(dest => dest.DID, pot => pot.MapFrom(src => src.DepartmentId));
        }
    }
}
