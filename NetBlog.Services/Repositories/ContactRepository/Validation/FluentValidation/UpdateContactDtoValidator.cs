using FluentValidation;
using NetBlog.Entities.Dtos.Contact;

namespace NetBlog.Business.Repositories.ContactRepository.Validation.FluentValidation
{
    public class UpdateContactDtoValidator : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactDtoValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithErrorCode("100").WithMessage("{PropertyName} must be greater than Zero");
            RuleFor(c => c.LastModifiedBy)
                .NotEmpty().WithErrorCode("101").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("101").WithMessage("{PropertyName} is not null ");
            RuleFor(c => c.Email)
                .NotEmpty().WithErrorCode("103").WithMessage("{PropertyName} is not empty")
                .EmailAddress().WithErrorCode("103").WithMessage("please enter a valid {PropertyName}")
                .NotNull().WithErrorCode("103").WithMessage("{PropertyName} is not null ");
            RuleFor(c => c.Title)
                .NotEmpty().WithErrorCode("103").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("103").WithMessage("{PropertyName} is not null ");
            RuleFor(c => c.Content)
                .NotEmpty().WithErrorCode("104").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("104").WithMessage("{PropertyName} is not null ");
        }
    }
}
