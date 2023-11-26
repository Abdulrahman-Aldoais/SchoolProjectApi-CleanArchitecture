
using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommands : IRequest<Response<string>>
    {
        public Guid Id { get; set; }

        public DeleteStudentCommands(Guid id)
        {
            Id = id;
        }
    }
}
