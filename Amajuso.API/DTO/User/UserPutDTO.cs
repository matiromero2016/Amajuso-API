using Amajuso.Domain.Entities;
using Amajuso.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace Amajuso.API.DTO
{
        public class UserPutDTO
    {
        ///<summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "This field is required")]
        public long Id {get;set;}

        ///<summary>
        /// Nombre
        /// </summary>
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        ///<summary>
        /// Apellido 
        /// </summary>
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        ///<summary>
        /// Email 
        /// </summary>
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; }

        ///<summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; }

        ///<summary>
        /// Autenticación via Google
        /// </summary>
        public string GoogleGuid { get; set; }

        ///<summary>
        /// Autenticación via Facebook
        /// </summary>
        public string FacebookGuid { get; set; }

        ///<summary>
        /// Teléfono 
        /// </summary>
        public string Phone {get;set;}

        ///<summary>
        /// Fecha de nacimiento
        /// </summary>
        public string Birthday {get;set;}

        ///<summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }

        ///<summary>
        /// Rol de usuário
        /// </summary>
        public string Role {get;set;}
        public User ToModel()
        {
            return new User
            {
                Id = this.Id,
                Name = this.Name,
                LastName = this.LastName,
                Email = this.Email,
                Password = this.Password,
                FacebookGuid = this.FacebookGuid,
                GoogleGuid = this.GoogleGuid,
                Phone = this.Phone,
                Birthday = this.Birthday,
                Gender = this.Gender,
                Role = this.Role
            };
        }
    }
}
