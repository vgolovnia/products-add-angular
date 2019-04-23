using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DMD.Test.Server
{
    public class AuthOptions
    {
        public const string Issuer = "DMD.Test.Server";
        public const string Audience = "https://localhost:44385/";  
        public const int Lifetime = 10;
        private const string Key = "mysupersecret_secretkey!123";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
