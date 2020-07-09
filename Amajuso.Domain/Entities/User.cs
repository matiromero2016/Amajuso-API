using System;
using System.ComponentModel.DataAnnotations;

namespace Amajuso.Domain.Entities
{
public class User : BaseEntity {
    [Required]
    public string Name {get;set;}
    [Required]
    public string LastName {get;set;}
    [Required]
    public string Email {get;set;}
    public string Password {get;set;}
    public string GoogleGuid { get; set; }
    public string FacebookGuid { get; set; }
    public string Phone {get;set;}
    public string Birthday {get;set;}
    public string Gender { get; set; }
    public string Role {get;set;}
    public long Terms { get; set; }
}

}