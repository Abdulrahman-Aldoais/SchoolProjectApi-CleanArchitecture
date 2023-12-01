using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validitors
{
    public class EditStudentValiditors : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;

        #endregion


        #region Constractors
        public EditStudentValiditors(IStudentService studentService)
        {
            _studentService = studentService;

            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Action

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .NotNull().WithMessage(SharedResourcesKeys.NotEmpty)
                .MaximumLength(30).WithMessage(SharedResourcesKeys.MaxLengthis100);

            RuleFor(x => x.Address).NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty).NotNull().WithMessage(SharedResourcesKeys.NotEmpty).MaximumLength(10).WithMessage(SharedResourcesKeys.MaxLengthis100);
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(key, model.Id))
                .WithMessage(SharedResourcesKeys.IsExist);
        }
        #endregion
    }


}
