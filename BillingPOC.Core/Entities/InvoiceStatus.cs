using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.Entities
{
    public class InvoiceStatus
    {
        [Key]
        public int InvoiceStatusId { get; set; }
        public string Name { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
