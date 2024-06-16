using BillingPOC.Core.Entities;
using BillingPOC.Core.Interfaces.Repositories;
using BillingPOC.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.DAL.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Patient?> GetRelatedPatientData(int patientId)
        {
            return await _context.Patients
                .Include(p => p.Invoices)
                    .ThenInclude(i => i.PatientMedicalProcedures)
                .FirstOrDefaultAsync(p => p.PatientId == patientId);
        }
    }
}
