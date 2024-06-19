using BillingPOC.Core.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingPOC.Core.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int PlanId { get; set; }
        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }
        public decimal CoInsurance { get; set; }
        public bool IsVIP { get; set; } = false;
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<PatientRuleHistory> PatientRuleHistories { get; set; }
    }
}
