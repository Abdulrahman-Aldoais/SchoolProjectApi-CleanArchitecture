using MediatR;
using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Students.Querise.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListRespons>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderByEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
