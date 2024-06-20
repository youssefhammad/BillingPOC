using BillingPOC.Core.Entities;
using BillingPOC.Core.Interfaces.Repositories;
using BillingPOC.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.DAL.Repositories
{
    public class MedicalProceduresReposiory : GenericRepository<MedicalProcedure>, IMedicalProceduresRepository
    {
        public MedicalProceduresReposiory(ApplicationDbContext context) : base(context)
        {
        }
    }
}
