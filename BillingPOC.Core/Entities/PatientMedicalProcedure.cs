using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Diagnostics.Contracts;

namespace BillingPOC.Core.Entities
{
    public class PatientMedicalProcedure
    {
        [Key]
        public int PatientMedicalProcedureId { get; set; }
        public int MedicalProcedureId { get; set; }
        [ForeignKey("MedicalProcedureId")]
        public MedicalProcedure MedicalProcedure { get; set; }
        public int? InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
        public DateTime ProcedureDate { get; set; }
        public decimal OutOfPocketCost { get; set; } // This term  describe the patient's financial responsibility
        public decimal CoveredAmount { get; set; } // This term describe the insurance company's payment responsibility
        public int? ProcedureStatusId { get; set; }
        [ForeignKey("ProcedureStatusId")]
        public ProcedureStatus ProcedureStatus { get; set; }

    }
}
