using System.Security.Claims;

namespace NetBlog.Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            return claimsPrincipal?.FindAll(claimType)?.Select(p => p.Value).ToList();
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
            //var result = claimsPrincipal?.FindAll(ClaimTypes.Role).Select(p => p.Value).ToList();
            //return result;
        }

    }
}
