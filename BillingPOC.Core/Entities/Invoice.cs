using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime DateTime { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        public int? InvoiceStatusId { get; set; }
        [ForeignKey("InvoiceStatusId")]
        public InvoiceStatus InvoiceStatus { get; set; }
        public decimal Charge {  get; set; }
        public decimal Discount { get; set; }
        public ICollection<PatientMedicalProcedure> PatientMedicalProcedures { get; set; }
    }
}
