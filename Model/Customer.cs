using System.Collections.Generic;

namespace FirstExercice.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
    }
}
