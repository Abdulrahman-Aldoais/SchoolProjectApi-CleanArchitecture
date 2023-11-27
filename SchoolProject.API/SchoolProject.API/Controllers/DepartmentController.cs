using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Depatrment.Querise.Models;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet("GetDepartmentList")]
        public async Task<IActionResult> GetDepartmentList()
        {

            return NewResult(await Mediator.Send(new GetDepartmentListQuery()));
        }
    }
}
