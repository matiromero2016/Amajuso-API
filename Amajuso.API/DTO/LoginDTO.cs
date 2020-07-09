using System.ComponentModel.DataAnnotations;

namespace Amajuso.API.DTO
{
    public class LoginDTO
    {
        /// <summary>
        /// E-mail
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Llave de accesso, puede ser la contraseña del usuario, el token de Google, el token de Facebook o el RefreshToken
        /// </summary>
        [Required(ErrorMessage = "This field is required")]
        public string AccessKey { get; set; }

        /// <summary>
        /// Tipo de accesso: password, refresh_token, google, facebook
        /// </summary>
        [Required(ErrorMessage = "This field is required")]
        public string GrantType { get; set; }
    }
}