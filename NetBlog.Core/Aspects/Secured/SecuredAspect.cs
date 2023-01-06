using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NetBlog.Core.Extensions;
using NetBlog.Core.Utilities.Interceptors;
using NetBlog.Core.Utilities.IoC;
using System.Linq;

namespace NetBlog.Core.Aspects.Secured
{
    public class SecuredAspect : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredAspect()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public SecuredAspect(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            if(_roles != null) // rol bazlı doğrulama
            {
                var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
                foreach (var role in _roles)
                {
                    if (roleClaims.Contains(role))
                    {
                        return;
                    }
                }
                throw new Exception("İşlem için yetkili değilsiniz.");
            }
            else // giriş doğrulama!
            {
                var claim = _httpContextAccessor?.HttpContext.User.Claims;
                if (claim.Count() > 0)
                {
                    return;
                }
                throw new Exception("İşlem için giriş yapmanız gerekir.");
            }
        }
    }
}
