using FluentValidation;
using NetBlog.Entities.Dtos.Category;

namespace NetBlog.Business.Repositories.CategoryRepository.Validation.FluentValidation
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithErrorCode("100").WithMessage("Id must be greater than Zero");
            RuleFor(c => c.LastModifiedBy).NotEmpty().WithErrorCode("101").WithMessage("CreatedBy is not empty")
                                          .NotNull().WithErrorCode("101").WithMessage("CreatedBy is not null");
            RuleFor(c => c.Name).NotEmpty().WithErrorCode("102").WithMessage("Name is not empty")
                                .NotNull().WithErrorCode("102").WithMessage("Name is not null ");
        }
    }
}
