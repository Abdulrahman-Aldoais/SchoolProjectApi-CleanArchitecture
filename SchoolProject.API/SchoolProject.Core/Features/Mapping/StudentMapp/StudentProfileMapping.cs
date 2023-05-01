using AutoMapper;
using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Mapping.StudentMapp
{
    public partial class StudentProfileMapping:Profile
    {
        public StudentProfileMapping()
        {
            GetStudentListMapping();
                
        }
    }
}
