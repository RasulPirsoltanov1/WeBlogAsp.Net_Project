using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Core.DAL
{
    public static class TokenGenerator
    {
        public static string CreateJwtToken()
        {
            byte[] bytes = Encoding.UTF8.GetBytes("itisaissuersiginkeyforauthentication");
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(bytes);
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Rasul_Pirsoltanov"),
                new Claim(ClaimTypes.Country,"Aze"),
                new Claim(ClaimTypes.Email,"rasul_pirsoltanov@gmail.com"),
            };
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: "http://localhost",
                audience: "http://localhost",
                claims: claims,
                notBefore: null,
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
