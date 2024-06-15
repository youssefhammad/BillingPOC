using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.ViewModels
{
    public class PatientProcedureResult
    {
        public int PatientId { get; set; }
        public int PlanId { get; set; }
        public int MedicalProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public int ProcedureConfigurationId { get; set; }
    }
}
