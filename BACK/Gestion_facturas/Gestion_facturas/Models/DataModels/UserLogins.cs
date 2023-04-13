using System.ComponentModel.DataAnnotations;
namespace Gestion_facturas.Models.DataModels
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get;set; }
    }
}
