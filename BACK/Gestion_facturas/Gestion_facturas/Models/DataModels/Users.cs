using System.ComponentModel.DataAnnotations;

namespace Gestion_facturas.Models.DataModels
{
    public enum Rol
    {
        Admin,
        User
    }
    public class Users : BaseEntity
    {
        [Required, StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Password { get; set; } = string.Empty.ToString();

        [Required]
        public Rol Rol { get; set; }= Rol.User;

       
    }
}
