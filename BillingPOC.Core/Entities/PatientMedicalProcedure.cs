using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BillingPOC.Core.Entities
{
    public class PatientMedicalProcedure
    {
        [Key]
        public int PatientMedicalProcedureId { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        public int MedicalProcedureId { get; set; }
        [ForeignKey("MedicalProcedureId")]
        public MedicalProcedure MedicalProcedure { get; set; }

        public DateTime ProcedureDate { get; set; }
    }
}
