using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
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
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .NotNull().WithMessage(SharedResourcesKeys.NotEmpty)
                .MaximumLength(30).WithMessage(SharedResourcesKeys.MaxLengthis100);

            RuleFor(x => x.NameEn)
              .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
              .NotNull().WithMessage(SharedResourcesKeys.NotEmpty)
              .MaximumLength(30).WithMessage(SharedResourcesKeys.MaxLengthis100);

            RuleFor(x => x.Address)
             .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
             .NotNull().WithMessage(SharedResourcesKeys.NotEmpty)
             .MaximumLength(10).WithMessage(SharedResourcesKeys.MaxLengthis100);
        }



        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage("اسم الطالب بالعربية مطلوب")
                .MaximumLength(100).WithMessage("يجب أن لا يتجاوز طول الاسم 100 حرف");

            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage("اسم الطالب بالإنجليزية مطلوب")
                .MaximumLength(100).WithMessage("يجب أن لا يتجاوز طول الاسم 100 حرف");
        }

        #endregion
    }
}
