using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PA_API.Models.User;

namespace PA_API.Services
{
    public static class TokenService
    {
        private static readonly string JWTKey = "JWTKey";

        public static string GenerateToken(UserViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = GetJWTKey();
            
            if (string.IsNullOrEmpty(jwtKey))
                throw new Exception("Missing JWT configuration");

            var key = Encoding.ASCII.GetBytes(jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static string GetJWTKey()
        {
            var executionPath = Assembly.GetExecutingAssembly().Location;
            var file = new FileInfo(executionPath);

            if (file.Directory == null)
                return null;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(file.Directory.FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration[JWTKey];
        }
    }
}