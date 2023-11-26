﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validitors
{
    public class EditStudentValiditors : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion


        #region Constractors
        public EditStudentValiditors(IStudentService studentService, IStringLocalizer<SharedResources> localizer)
        {
            _studentService = studentService;
            _localizer = localizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Action

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(30).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.Address)
             .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
             .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
             .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(key, model.Id))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }


}
