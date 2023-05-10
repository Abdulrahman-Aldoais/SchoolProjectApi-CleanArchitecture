using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validitors
{
    public class AddStudentValidirors : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion


        #region Constractors
        public AddStudentValidirors(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Action

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(" Name Must not be Empty")
                .NotNull().WithMessage(" Name Must not be null")
                .MaximumLength(30).WithMessage(" Max length is 30");

            RuleFor(x => x.Address)
             .NotEmpty().WithMessage(" Address Must not be Empty")
             .NotNull().WithMessage(" Address Must not be null")
             .MaximumLength(10).WithMessage(" Max length is 10");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key))
                .WithMessage("Name is Exist!!");
        }
        #endregion
    }
}
