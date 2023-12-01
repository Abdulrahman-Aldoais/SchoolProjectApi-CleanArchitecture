using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Querise.Models;
using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Core.Resources;
using SchoolProject.Infrastructure.InfrastructuerBase;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Querise.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListRespons>>>,
                                                       IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>
    {
        #region Filde
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<GetStudentListRespons> _genericRepositoryAsync;

        #endregion

        #region Constructors
        public StudentQueryHandler(IStudentService studentService,
                                   IMapper mapper,
                                   IGenericRepositoryAsync<GetStudentListRespons> genericRepositoryAsync

                                   )
        {
            _studentService = studentService;
            _genericRepositoryAsync = genericRepositoryAsync;
            _mapper = mapper;
            //Options = options;
        }
        #endregion

        #region Handle Function
        public async Task<Response<List<GetStudentListRespons>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            //var studentList = await _genericRepositoryAsync.GetStudentDynamicWithOdata(request.Options);
            var studentList = _studentService.GetStudentsLsitAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListRespons>>(studentList);
            return Success(studentListMapper);
        }

        public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludAsync(request.Id);
            if (student == null) return NotFound<GetStudentByIdResponse>(SharedResourcesKeys.NotFound);
            var result = _mapper.Map<GetStudentByIdResponse>(student);
            return Success(result);
        }


        #endregion


    }
}
