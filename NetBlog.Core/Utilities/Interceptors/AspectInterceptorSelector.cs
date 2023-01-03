using Castle.DynamicProxy;
using System.Reflection;

namespace NetBlog.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList(); //ana clas üzrinde bir attribute var mı diye bakıyor.
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            //method üzerinde bir attribute var mı diye bakıyor.

            classAttributes.AddRange(methodAttributes); //birleştiriyor.
            return classAttributes.ToArray(); // array dönüyor.
        }
    }
}
