using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Depatrment.Querise.Models;
using SchoolProject.Core.Features.Depatrment.Querise.Respons;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Depatrment.Querise.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentListQuery, Response<List<GetDepartmentListRespons>>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;

        public DepartmentQueryHandler(IMapper mapper, IStringLocalizer<SharedResources> localizer, IDepartmentService departmentService) : base(localizer)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _localizer = localizer;
        }
        public async Task<Response<List<GetDepartmentListRespons>>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _departmentService.GetDepartmentLsitAsync();
            var studentListMapper = _mapper.Map<List<GetDepartmentListRespons>>(studentList);
            return Success(studentListMapper);
        }
    }
}
