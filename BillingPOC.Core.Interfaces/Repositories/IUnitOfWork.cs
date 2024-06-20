using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        IUserRepository User { get; }
        IPatientProcedureResultRepository PatientProcedureViewResult { get; }
        IPatientInvoiceResultRepository PatientInvoiceResult { get; }
        IPatientRepository Patient { get; }
        IMedicalProceduresRepository MedicalProcedures { get; }
        IInvoiceRepository Invoice {  get; }
        Task<int> CompleteAsync();
    }
}
