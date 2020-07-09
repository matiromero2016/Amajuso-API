using System;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using Amajuso.Domain.Utils;
using Amajuso.Domain.Entities;
using Amajuso.Service;
using System.Linq;

namespace Amajuso.Services
{
    public class TokenService
    {
        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;
        public TokenService(SigningConfiguration signingConfiguration, TokenConfiguration tokenConfiguration)
        {
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }

        /// <summary>
        /// Genera el RefreshToken utilizado para generar nuevamente el JWT sin necesidad de loguear de nuevo
        /// </summary>
        /// <param name="userID">Id del usuario</param>
        /// <returns>RefreshToken</returns>
        private string WriteRefresh(long userID)
        {
            return CryptographyService.Crypt($"{userID}#{DateTime.UtcNow.AddDays(90).Ticks}");
        }

        public Token GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            DateTime created = DateTime.Now;
            DateTime expire = created + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);
            string refreshToken = WriteRefresh(user.Id);
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Id.ToString(), "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                        new Claim(ClaimTypes.Hash, refreshToken)
                    }
                    
                );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = created,
                Expires = expire
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return new Token(token, refreshToken, "bearer", expire.Ticks);
        }
    }
}
