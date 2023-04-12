using System.ComponentModel.DataAnnotations;

namespace Gestion_facturas.Models.DataModels
{
    public class Invoice : BaseEntity
    {
        [Required]
        public string NumeroFactura { get; set; } = string.Empty;

        [Required]
        public decimal TotalFactura { get; set; }

        [Required]
        public Enterprise enterprise { get; set; } = new Enterprise();

        [Required]
        public ICollection<InvoiceLine> InvoiveLine { get; set; } = new List<InvoiceLine>(); 
    }
}
