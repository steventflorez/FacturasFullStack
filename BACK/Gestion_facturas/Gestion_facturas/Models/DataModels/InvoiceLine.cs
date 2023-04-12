using System.ComponentModel.DataAnnotations;

namespace Gestion_facturas.Models.DataModels
{
    public class InvoiceLine : BaseEntity
    {
        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal TotalLinea { get; set; }

        [Required]
        public Invoice Invoice { get; set; } = new Invoice();
    }
}
