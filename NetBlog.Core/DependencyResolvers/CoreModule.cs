﻿using Microsoft.Extensions.DependencyInjection;
using NetBlog.Core.CrossCuttingConcerns.Caching;
using NetBlog.Core.CrossCuttingConcerns.Caching.Microsoft;
using NetBlog.Core.Utilities.IoC;

namespace NetBlog.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
