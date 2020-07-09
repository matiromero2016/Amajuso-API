using System.ComponentModel.DataAnnotations;

namespace Amajuso.Domain.Utils {
public static class Role
    {
        public const string Administrator = "Administrator";
        public const string Visitor = "Visitor";
    }
public enum Roles
    {
        [Display(Name = "Visitor")]
        Visitor = 0,

        [Display(Name = "Administrator")]
        Administrator = 1
    }
}