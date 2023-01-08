using FluentValidation;
using NetBlog.Entities.Dtos.Post;

namespace NetBlog.Business.Repositories.PostRepository.Validation.FluentValidation
{
    internal class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
    {
        public UpdatePostDtoValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithErrorCode("100").WithMessage("{PropertyName} must be greater than Zero");
            RuleFor(c => c.LastModifiedBy)
                .NotEmpty().WithErrorCode("101").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("101").WithMessage("{PropertyName} is not null");
            RuleFor(c => c.Title)
                .NotEmpty().WithErrorCode("102").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("102").WithMessage("{PropertyName} is not null ");
            RuleFor(c => c.Content)
                .NotEmpty().WithErrorCode("103").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("103").WithMessage("{PropertyName} is not null");
            RuleFor(c => c.Thumbnail)
                .NotEmpty().WithErrorCode("104").WithMessage("{PropertyName} is not empty")
                .NotNull().WithErrorCode("104").WithMessage("{PropertyName} is not null ");
            RuleFor(c => c.CategoryId)
                .GreaterThan(0).WithErrorCode("105").WithMessage("{PropertyName} must be greater than Zero");
        }
    }
}
