using Amajuso.Domain.Entities;
using Amajuso.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace Amajuso.API.DTO
{
        public class UserPostDTO
    {
        ///<summary>
        /// Nombre
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        ///<summary>
        /// Apellido 
        /// </summary>
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string LastName { get; set; }

        ///<summary>
        /// Email 
        /// </summary>
        [Required(ErrorMessage = "Debe enviar un email")]
        [EmailAddress(ErrorMessage = "Debe enviar un email válido")]
        public string Email { get; set; }

        ///<summary>
        /// Teléfono 
        /// </summary>
        public string Phone { get; set; }

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
        /// Fecha de nacimiento
        /// </summary>
        public string Birthday {get;set;}

        ///<summary>
        /// Género
        /// </summary>
        public string Gender { get; set; }
        ///<summary>
        /// Rol de usuário
        /// </summary>
        public string Role {get;set;}

        ///<summary>
        /// Términos y condiciones
        /// </summary>
        [Required]
        public long Terms { get; set; }
        public User ToModel()
        {
            return new User
            {
                Name = this.Name,
                LastName = this.LastName,
                Email = this.Email,
                Password = this.Password,
                FacebookGuid = this.FacebookGuid,
                GoogleGuid = this.GoogleGuid,
                Phone = this.Phone,
                Birthday = this.Birthday,
                Gender = this.Gender,
                Role = this.Role,
                Terms = this.Terms
            };
        }
    }
}
