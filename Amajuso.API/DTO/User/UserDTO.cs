using Amajuso.Domain.Entities;

namespace Amajuso.API.DTO {

    public class UserDTO {

        public long Id { get; set; }
        public string Name {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string Phone {get;set;}
        public string Birthday {get;set;}
        public string Gender { get; set; }
        public string Role { get;set; }
        public long Terms { get; set; }

        public UserDTO(User obj) {
            this.Id = obj.Id;
            this.Name = obj.Name;
            this.LastName = obj.LastName;
            this.Email = obj.Email;
            this.Phone = obj.Phone;
            this.Birthday = obj.Birthday;
            this.Gender = obj.Gender;
            this.Role = obj.Role;
            this.Terms = obj.Terms;
        }
    }
}