using BillingPOC.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.Interfaces.Repositories
{
    public interface IPatientInvoiceResultRepository : IGenericRepository<PatientInvoiceResult>
    {
        Task<IEnumerable<PatientInvoiceResult>> GetPatientInvoiceResultsAsync(int patientId);
    }
}
