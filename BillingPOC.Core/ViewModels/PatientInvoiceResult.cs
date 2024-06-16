using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.ViewModels
{
    public class PatientInvoiceResult
    {
        public int InvoiceId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateTime { get; set; }
        public int InvoiceStatusId { get; set; }
        public decimal Charge { get; set; }
        public decimal Discount { get; set; }
    }
}
