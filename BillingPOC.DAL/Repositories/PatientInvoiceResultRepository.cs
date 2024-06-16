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
    public class PatientInvoiceResultRepository : GenericRepository<PatientInvoiceResult>, IPatientInvoiceResultRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientInvoiceResultRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientInvoiceResult>> GetPatientInvoiceResultsAsync(int patientId)
        {
            return await _context.PatientInvoiceResults
                                .Where(p => p.PatientId == patientId)
                                .ToListAsync();
        }
    }
}
