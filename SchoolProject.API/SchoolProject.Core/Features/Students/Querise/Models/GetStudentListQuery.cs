using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Querise.Models
{
    // Request "GetStudentListQuery" and Response List<Student>
    public class GetStudentListQuery:IRequest<Response<List<GetStudentListRespons>>>
    {
    }
}
