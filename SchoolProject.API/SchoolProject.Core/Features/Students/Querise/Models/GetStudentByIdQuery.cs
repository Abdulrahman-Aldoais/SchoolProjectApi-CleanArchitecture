using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Querise.Respons;

namespace SchoolProject.Core.Features.Students.Querise.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetStudentByIdResponse>>
    {
        public GetStudentByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }//for request 
    }
}
