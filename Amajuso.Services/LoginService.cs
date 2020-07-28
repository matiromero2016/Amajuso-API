using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Paged;
using Amajuso.Service;
using Microsoft.AspNetCore.Mvc;

namespace Amajuso.Services {

    public class LoginService {

        private IService<User> _userService;
        private IService<BlackList> _blackListService;
        public LoginService(IService<User> userService, [FromServices] IService<BlackList> blackListService) {
            _userService = userService;
            _blackListService = blackListService;
        }
    
        public User ValidCredentials(string userID, string accessKey, string grantType)
        {
            User user = null;

            switch (grantType)
            {
                case "google":
                    // userBase = VerifyGoogle(accessKey);
                    break;
                case "facebook":
                    // userBase = VerifyFacebook(accessKey);
                    break;
                case "refresh_token":
                    user = VerifyRefresh(accessKey);
                    break;
                case "password":
                    user = VerifyPassword(userID, accessKey);
                    break;
            }

            return user;
        }

        /// <summary>
        /// Realiza la autenticación a tráves de Email y Password
        /// </summary>
        /// <param name="userID">E-mail del usuario</param>
        /// <param name="accessKey">Llave de accesso de tipo Password</param>
        /// <returns>Usuario caso exista</returns>
        private User VerifyPassword(string email, string accessKey)
        {
            User userBase = null;

            userBase = _userService.Where(p=> p.Email == email).Result.Items?.First();
            if (userBase != null && CryptographyService.Hash(accessKey) != userBase.Password)
                userBase = null;

            return userBase;
        }

        /// <summary>
        /// Realiza la autenticación a tráves del refresh token
        /// </summary>
        /// <param name="userID">E-mail del usuario</param>
        /// <param name="accessKey">Llave de accesso de tipo Refresh Token</param>
        /// <returns>Usuario caso exista</returns>
        public User VerifyRefresh(string accessKey)
        {
            User user = null;
            if (!string.IsNullOrWhiteSpace(accessKey))
            {
                var existRefresh = _blackListService.Exist(x => x.RefreshToken == accessKey).Result;
                if (existRefresh)
                    return user;
               
                accessKey = CryptographyService.Decrypt(accessKey);

                string[] parts = accessKey.Split('#');
                if (parts.Length == 2)
                {
                    DateTime end = new DateTime(Convert.ToInt64(parts[1]));
                    if (DateTime.UtcNow <= end)
                    {
                        user = _userService.Get(Convert.ToInt64(parts[0])).Result;
                    }
                }
            }
            return user;
        }
    }
}