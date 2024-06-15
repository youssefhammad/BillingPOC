using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BillingPOC.Core.Entities
{
    public class ProcedurePlanConfiguration
    {
        [Key]
        public int ProcedurePlanConfigurationId { get; set; }

        public int PlanId { get; set; }
        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }

        public int MedicalProcedureId { get; set; }
        [ForeignKey("MedicalProcedureId")]
        public MedicalProcedure MedicalProcedure { get; set; }

        public int ProcedureConfigurationId { get; set; }
        [ForeignKey("ProcedureConfigurationId")]
        public ProcedureConfiguration ProcedureConfiguration { get; set; }
    }
}
