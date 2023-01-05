using Microsoft.Extensions.DependencyInjection;

namespace NetBlog.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
