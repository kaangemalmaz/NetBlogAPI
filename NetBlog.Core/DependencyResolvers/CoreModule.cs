using Microsoft.Extensions.DependencyInjection;
using NetBlog.Core.Utilities.IoC;

namespace NetBlog.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}
