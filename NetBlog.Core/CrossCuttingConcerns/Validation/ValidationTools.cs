using FluentValidation;

namespace NetBlog.Core.CrossCuttingConcerns.Validation
{
    public class ValidationTools
    {
        public static void Validation(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
