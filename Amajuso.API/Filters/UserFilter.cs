namespace Amajuso.API.Filters
{
    public class UserFilter : BaseFilter
    {
        /// <summary>
        ///  Busca usuarios donde el nombre contiene el valor enviado
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Busca usuarios donde el apellido contiene el valor enviado
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Busca usuarios donde el email contiene el valor enviado
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Busca usuarios donde el documento contiene el valor enviado
        /// </summary>
        public string Phone { get; set; }

    }
}