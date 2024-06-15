using System.ComponentModel.DataAnnotations;

namespace BillingPOC.Core.Entities
{
    public class ProcedureStatus
    {
        [Key]
        public int ProcedureStatusId { get; set; }
        public string Name { get; set; }
        public ICollection<PatientMedicalProcedure> patientMedicalProcedures { get; set; }
    }
}
