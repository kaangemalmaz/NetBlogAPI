using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using NetBlog.Core.CrossCuttingConcerns.Caching;
using NetBlog.Core.Utilities.Interceptors;
using NetBlog.Core.Utilities.IoC;

namespace NetBlog.Core.Aspects.Caching
{
    public class RemoveCacheAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public RemoveCacheAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }


    }
}
