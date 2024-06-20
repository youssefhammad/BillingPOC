using BillingPOC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.Interfaces.Repositories
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<Patient?> GetRelatedPatientData(int patientId);
        Task<IEnumerable<Patient?>> GetRelatedPatientWithPlan();
        Task<IEnumerable<Invoice>> GetPatientInvoices(int patientId);
        Task<IEnumerable<PatientMedicalProcedure>> GetPatientMedicalProcedures(List<int> invoiceId);
    }
}
