using FluentValidation;
using NetBlog.Entities.Dtos.Category;

namespace NetBlog.Business.Repositories.CategoryRepository.Validation.FluentValidation
{
    public class AddCategoryDtoValidator : AbstractValidator<AddCategoryDto>
    {
        public AddCategoryDtoValidator()
        {
            RuleFor(c => c.CreatedBy).NotEmpty().WithErrorCode("101").WithMessage("CreatedBy is not empty")
                                     .NotNull().WithErrorCode("101").WithMessage("CreatedBy is not null");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name not be empty").WithErrorCode("102")
                                .NotNull().WithErrorCode("102").WithMessage("Name is not null and empty");
        }
    }
}
