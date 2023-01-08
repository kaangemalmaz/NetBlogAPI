using FluentValidation;
using NetBlog.Entities.Dtos.Contact;

namespace NetBlog.Business.Repositories.ContactRepository.Validation.FluentValidation
{
    public class AddContactDtoValidator : AbstractValidator<AddContactDto>
    {
        public AddContactDtoValidator()
        {
            RuleFor(c => c.CreatedBy)
                .NotEmpty().WithErrorCode("101").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("101").WithMessage("{PropertyName} is not null ");
            RuleFor(c => c.Email)
                .NotEmpty().WithErrorCode("102").WithMessage("{PropertyName} is not empty")
                .EmailAddress().WithErrorCode("102").WithMessage("Please enter a valid {PropertyName}")
                .NotNull().WithErrorCode("102").WithMessage("{PropertyName} is not null ");
            RuleFor(c => c.Title)
                .NotEmpty().WithErrorCode("103").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("103").WithMessage("{PropertyName} is not null ");
            RuleFor(c => c.Content)
                .NotEmpty().WithErrorCode("104").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("104").WithMessage("{PropertyName} is not null ");
        }
    }
}
