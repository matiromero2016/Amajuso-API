using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Paged;
using Amajuso.Service;

namespace Amajuso.Services {

    public class LoginService {

        private IService<User> _userService;
        public LoginService(IService<User> userService) {
            _userService = userService;
        }
    
        public User ValidCredentials(string userID, string accessKey, string grantType)
        {
            User userBase = null;

            switch (grantType)
            {
                case "google":
                    // userBase = VerifyGoogle(accessKey);
                    break;
                case "facebook":
                    // userBase = VerifyFacebook(accessKey);
                    break;
                case "refresh_token":
                    // userBase = VerifyRefresh(accessKey);
                    break;
                case "password":
                    userBase = VerifyPassword(userID, accessKey);
                    break;
            }

            return userBase;
        }

        /// <summary>
        /// Realiza la autenticación atráves de Email y Password
        /// </summary>
        /// <param name="userID">E-mail do usuário</param>
        /// <param name="accessKey">Chave de acesso do tipo Password</param>
        /// <returns>Usuário caso exista</returns>
        private User VerifyPassword(string email, string accessKey)
        {
            User userBase = null;

            userBase = _userService.Where(p=> p.Email == email).Result.Items?.First();
            if (userBase != null && CryptographyService.Hash(accessKey) != userBase.Password)
                userBase = null;

            return userBase;
        }
    }
}