using BillingPOC.Core.Entities;
using BillingPOC.Core.Enums;
using BillingPOC.Core.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<MedicalProcedure> MedicalProcedures { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicalProcedure> PatientMedicalProcedures { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<ProcedureConfiguration> ProcedureConfigurations { get; set; }
        public DbSet<ProcedurePlanConfiguration> ProcedurePlanConfigurations { get; set; }
        public DbSet<PatientProcedureResult> PatientProcedureResults { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);

            builder.Entity<PatientProcedureResult>(entity =>
            {
                entity.ToView("PatientProcedureResultView");
                entity.HasNoKey(); 
            });

        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = EnRoles.Administrator.ToString(),
                    NormalizedName = EnRoles.Administrator.ToString().ToUpper(),
                    DisplayName = "Administrator"
                },
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = EnRoles.InsuranceCoordinator.ToString(),
                    NormalizedName = EnRoles.InsuranceCoordinator.ToString().ToUpper(),
                    DisplayName = "Insurance Coordinator"
                },
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = EnRoles.Accountant.ToString(),
                    NormalizedName = EnRoles.Accountant.ToString().ToUpper(),
                    DisplayName = "Accountant"
                },
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = EnRoles.Auditor.ToString(),
                    NormalizedName = EnRoles.Auditor.ToString().ToUpper(),
                    DisplayName = "Auditor"
                }
            );
        }
    }
}
