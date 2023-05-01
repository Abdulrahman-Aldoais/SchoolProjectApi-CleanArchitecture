using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Querise.Models;
using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Querise.Handlers
{
    public class StudentQueryHandler :ResponseHandler, IRequestHandler<GetStudentListQuery,Response< List<GetStudentListRespons>>>
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
        #endregion


    }
}
