using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                         IRequestHandler<AddStudentCommand, Response<string>>,
                                         IRequestHandler<EditStudentCommand, Response<string>>,
                                         IRequestHandler<DeleteStudentCommands, Response<string>>
    {

        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion


        #region Handler Function
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            // mapping between requst and student
            var studntResult = _mapper.Map<Student>(request);
            // add
            var result = await _studentService.AddStudentAsync(studntResult);
            //// check condation 
            //if (result == "Exist") return UnprocessableEntity<string>("Name Is Exist");
            // retutrn responst
            if (result == "Success") return Created("Added SuccessFully");
            else return BadRequest<string>("error not now");
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // check if the stuent Exist or not
            var student = await _studentService.GetByIdAsync(request.Id);
            // return Not fonde 
            if (student == null) return NotFound<string>(" Student is not fonde");
            // mapping between requst and student
            var studentMapper = _mapper.Map<Student>(request);
            // Edit
            var result = await _studentService.EditStudentAsync(studentMapper);
            //check return result 
            if (result == "Success") return Success($"Edit Success {studentMapper.StudID}");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommands request, CancellationToken cancellationToken)
        {
            //check if the student Exist or not
            var student = await _studentService.GetByIdAsync(request.Id);
            // return Not Fonde
            if (student == null) return NotFound<string>("Student is Not found");
            // call function from service to delete this student
            var result = await _studentService.DeleteStudentAsync(student);
            //check return result 
            if (result == "Success") return Deleted<string>($"Delete Success {request.Id}");
            else return BadRequest<string>();

        }



        #endregion

    }
}
