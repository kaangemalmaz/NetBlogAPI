using Castle.DynamicProxy;
using FluentValidation;
using NetBlog.Core.CrossCuttingConcerns.Validation;
using NetBlog.Core.Utilities.Interceptors;

namespace NetBlog.Core.Aspects.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if(!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Hatali validation sinifi");
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = Activator.CreateInstance(_validatorType) as IValidator;
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // validation implementasyonu sırasında aldığı argümana bakar.
            var entities = invocation.Arguments.Where(p => p.GetType() == entityType); // o methodun tüm argumanlarını alıp type'i ana argümanla uyuşanları filtreler.
            foreach ( var entity in entities )
            {
                ValidationTools.Validation(validator, entity);
            }
        }

    }
}
