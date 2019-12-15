using System.ComponentModel.DataAnnotations.Schema;

namespace FirstExercice.Model
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
    }
}
