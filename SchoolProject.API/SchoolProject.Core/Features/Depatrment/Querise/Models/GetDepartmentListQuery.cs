using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Depatrment.Querise.Respons;

namespace SchoolProject.Core.Features.Depatrment.Querise.Models
{
    public class GetDepartmentListQuery : IRequest<Response<List<GetDepartmentListRespons>>>
    {
    }
}
