using BillingPOC.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.Interfaces.Repositories
{
    public interface IPatientProcedureResultRepository : IGenericRepository<PatientProcedureResult>
    {
        Task<IEnumerable<PatientProcedureResult>> GetPatientProcedureResultsAsync(int patientId);
    }
}
