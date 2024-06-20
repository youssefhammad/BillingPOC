using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.DTOs.Invoices
{
    public class InvoiceDto
    {
        public int PatientId { get; set; }
        public List<PatientMedicalProcedureDto> PatientMedicalProcedures { get; set; } = new List<PatientMedicalProcedureDto> { };
    }

    public class PatientMedicalProcedureDto
    {
        public int MedicalProcedureId { get; set; }
        public DateTime ProcedureDate { get; set; }

    }
}
