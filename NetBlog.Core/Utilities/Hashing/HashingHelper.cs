using System.Text;

namespace NetBlog.Core.Utilities.Hashing
{
    public class HashingHelper
    {
        public static void CreatePassword(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (passwordHash[i] != computeHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
