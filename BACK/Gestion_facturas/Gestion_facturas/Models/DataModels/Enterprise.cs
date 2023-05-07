using System.ComponentModel.DataAnnotations;

namespace Gestion_facturas.Models.DataModels
{
    public class Enterprise : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public Users Users { get; set; } = new Users();

        
       public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    }
}
