
using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommands : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteStudentCommands(int id)
        {
            Id = id;
        }
    }
}
