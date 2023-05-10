using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Querise.Models;
using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Querise.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListRespons>>>,
                                                       IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>
    {
        #region Filde
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        #endregion


        #region Constructors
        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
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
            if (student == null) return NotFound<GetStudentByIdResponse>("Object Not Found");
            var result = _mapper.Map<GetStudentByIdResponse>(student);
            return Success(result);
        }
        #endregion


    }
}
