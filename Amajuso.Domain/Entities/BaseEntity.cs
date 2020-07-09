using System;
using System.ComponentModel.DataAnnotations;

namespace Amajuso.Domain.Entities
{
public abstract class BaseEntity {

    [Required]
    public long Id { get; set; }
    public DateTime Created {get;set;}
    public DateTime Modified {get;set;}
}
}