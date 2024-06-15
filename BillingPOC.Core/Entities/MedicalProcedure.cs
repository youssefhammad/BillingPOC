using System.ComponentModel.DataAnnotations;

namespace BillingPOC.Core.Entities
{
    public class MedicalProcedure
    {
        [Key]
        public int MedicalProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public decimal Price { get; set; }

        public ICollection<ProcedurePlanConfiguration> ProcedurePlanConfigurations { get; set; }
        public ICollection<PatientMedicalProcedure> PatientMedicalProcedures { get; set; }
    }
}
