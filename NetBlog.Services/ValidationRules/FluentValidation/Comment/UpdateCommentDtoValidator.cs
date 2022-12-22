using FluentValidation;
using NetBlog.Entities.Dtos.Comment;

namespace NetBlog.Business.ValidationRules.FluentValidation.Comment
{
    internal class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
    {
        public UpdateCommentDtoValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithErrorCode("100").WithMessage("{PropertyName} must be greater than Zero");
            RuleFor(c => c.LastModifiedBy)
                .NotEmpty().WithErrorCode("101").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("101").WithMessage("{PropertyName} is not null ");
            RuleFor(c => c.Email)
                .NotEmpty().WithErrorCode("102").WithMessage("{PropertyName} is not empty")
                .EmailAddress().WithErrorCode("102").WithMessage("Please enter a valid {PropertyName}")
                .NotNull().WithErrorCode("102").WithMessage("{PropertyName} is not null ");
            RuleFor(c => c.Text)
                .NotEmpty().WithErrorCode("103").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("103").WithMessage("{PropertyName} is not null ");
            RuleFor(c => c.PostId)
                .GreaterThan(0).WithErrorCode("104").WithMessage("{PropertyName} must be greater than Zero");
        }
    }
}
