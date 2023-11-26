using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Querise.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{

    [ApiController]
    public class StudentController : AppControllerBase
    {

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            //var response = await Mediator.Send(new GetStudentListQuery());
            return NewResult(await Mediator.Send(new GetStudentListQuery()));
        }
        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> Paginted([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
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
        [HttpPut(Router.StudentRouting.Edit)]
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
