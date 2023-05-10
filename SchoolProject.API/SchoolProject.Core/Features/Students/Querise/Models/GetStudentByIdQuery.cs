using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Querise.Respons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Querise.Models
{
    public class GetStudentByIdQuery:IRequest<Response<GetStudentByIdResponse>>
    {
        public GetStudentByIdQuery(int id)
        {
            Id = id;   
        }
        public int Id { get; set; }//for request 
    }
}
