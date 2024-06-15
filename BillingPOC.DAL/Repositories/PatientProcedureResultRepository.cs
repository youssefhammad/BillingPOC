using BillingPOC.Core.Interfaces.Repositories;
using BillingPOC.Core.ViewModels;
using BillingPOC.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.DAL.Repositories
{
    public class PatientProcedureResultRepository : GenericRepository<PatientProcedureResult>, IPatientProcedureResultRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientProcedureResultRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientProcedureResult>> GetPatientProcedureResultsAsync(int patientId)
        {
            return await _context.PatientProcedureResults
                                 .Where(p => p.PatientId == patientId)
                                 .ToListAsync();
        }
    }
}
