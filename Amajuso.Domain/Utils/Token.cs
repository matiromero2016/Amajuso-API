using System;
using System.Collections.Generic;
using System.Text;

namespace Amajuso.Domain.Utils
{
    public class Token
    {
        public Token(string accessToken, string refreshToken, string tokenType, long expiresIn)
        {
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
            this.TokenType = tokenType;
            this.ExpiresIn = expiresIn;
        }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string TokenType { get; set; }
        public long ExpiresIn { get; set; }
    }
}
