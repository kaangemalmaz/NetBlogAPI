using NetBlog.Core.Entities.Concrete;

namespace NetBlog.Core.Utilities.Security.Jwt
{
    public interface ITokenHandler
    {
        Token CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
