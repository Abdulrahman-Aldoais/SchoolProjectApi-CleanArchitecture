using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Querise.Models;
using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Data.AppMetaData;



namespace SchoolProject.API.Controllers
{


    //[ODataRouteComponent("student")]
    public class StudentController : AppControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Router.StudentRouting.List)]
        [EnableQuery(AllowedArithmeticOperators = AllowedArithmeticOperators.All)]
        public async Task<IActionResult> GetStudentList()
        {
            //var response = await Mediator.Send(new GetStudentListQuery());
            return NewResult(await Mediator.Send(new GetStudentListQuery()));
        }

        [EnableQuery]
        [HttpGet("GetStudentsDynamic")]
        public async Task<IActionResult> GetStudentDynamic(ODataQueryOptions<GetStudentListRespons> options)
        {
            return Ok(await Mediator.Send(new GetStudentListQuery()));
        }



        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] Guid id)
        {
            //var response = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(await Mediator.Send(new GetStudentByIdQuery(id)));
        }

        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
        {
            //var respons = await Mediator.Send(command);
            return NewResult(await Mediator.Send(command));
        }
        [HttpPost(Router.StudentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand editStudent)
        {
            //var respons = await Mediator.Send(editStudent);
            return NewResult(await Mediator.Send(editStudent));
        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delet([FromRoute] Guid id)
        {
            return NewResult(await Mediator.Send(new DeleteStudentCommands(id)));
        }

    }
}
