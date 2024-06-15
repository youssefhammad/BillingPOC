using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BillingPOC.Core.Entities
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        public string PlanName { get; set; }

        public int InsuranceCompanyId { get; set; }
        [ForeignKey("InsuranceCompanyId")]
        public InsuranceCompany InsuranceCompany { get; set; }

        public ICollection<Patient> Patients { get; set; }
        public ICollection<ProcedurePlanConfiguration> ProcedurePlanConfigurations { get; set; }
    }
}
