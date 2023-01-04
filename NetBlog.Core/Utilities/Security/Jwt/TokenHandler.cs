using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NetBlog.Core.Entities.Concrete;
using NetBlog.Core.Extensions;
using System.Data.SqlTypes;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NetBlog.Core.Utilities.Security.Jwt
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //Security  Key'in simetriğini alıyoruz.
            Token token = new Token();
            token.Expiration= DateTime.Now.AddMinutes(60);

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

            //Oluşturulacak token ayarlarını veriyoruz.
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                claims: SetClaims(user, operationClaims),
                notBefore: DateTime.Now,
                expires: token.Expiration,
                signingCredentials: signingCredentials
                );

            // Token oluşturucu sınıfında bir örnek alıyoruz.
            JwtSecurityTokenHandler jwtSecurity = new JwtSecurityTokenHandler();
            token.AccessToken = jwtSecurity.WriteToken(jwtSecurityToken);
            token.RefreshToken = CreateRefreshToken();
            return token;
        }


        private string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claim = new List<Claim>();

            claim.AddName(user.Name);
            claim.AddEmail(user.Email);
            claim.AddNameIdentifier(user.Id.ToString());
            claim.AddRoles(operationClaims.Select(p=>p.Name).ToArray());

            return claim;

        }


    }
}
