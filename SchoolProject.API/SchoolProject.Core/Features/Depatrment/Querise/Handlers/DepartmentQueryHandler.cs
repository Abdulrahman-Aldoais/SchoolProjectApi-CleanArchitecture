using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Depatrment.Querise.Models;
using SchoolProject.Core.Features.Depatrment.Querise.Respons;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Depatrment.Querise.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentListQuery, Response<List<GetDepartmentListRespons>>>
    {
        private readonly IMapper _mapper;

        private readonly IDepartmentService _departmentService;

        public DepartmentQueryHandler(IMapper mapper, IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _mapper = mapper;

        }
        public async Task<Response<List<GetDepartmentListRespons>>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _departmentService.GetDepartmentLsitAsync();
            var studentListMapper = _mapper.Map<List<GetDepartmentListRespons>>(studentList);
            return Success(studentListMapper);
        }
    }
}
