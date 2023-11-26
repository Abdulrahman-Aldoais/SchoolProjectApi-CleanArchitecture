using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Querise.Models;
using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Querise.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListRespons>>>,
                                                       IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>,
                                                       IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListRespons>>
    {
        #region Filde
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion


        #region Constructors
        public StudentQueryHandler(IStudentService studentService,
                                   IMapper mapper,
                                   IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion

        #region Handle Function
        public async Task<Response<List<GetStudentListRespons>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsLsitAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListRespons>>(studentList);
            return Success(studentListMapper);
        }

        public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludAsync(request.Id);
            if (student == null) return NotFound<GetStudentByIdResponse>(_localizer[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetStudentByIdResponse>(student);
            return Success(result);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListRespons>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListRespons>> exception = e => new GetStudentPaginatedListRespons(e.StudID, e.NameAr, e.Address, e.Department.DNameAr);
            //  var queryable = _studentService.GetStudentQueryable();
            var FilterQuery = _studentService.FilterStudentPaginatedQueryable(request.OrderBy, request.Search);
            var PaginatedList = await FilterQuery.Select(exception).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return PaginatedList;
        }
        #endregion


    }
}
