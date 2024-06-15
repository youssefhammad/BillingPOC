using BillingPOC.Core.Entities;
using BillingPOC.Core.Interfaces.Repositories;
using BillingPOC.DAL.Data;
using BillingPOC.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private IUserRepository _userRepository;
        private IPatientProcedureResultRepository _patientProcedureResultRepository;
        private IPatientRepository _patientRepository;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<User> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new GenericRepository<TEntity>(_context);
            _repositories[typeof(TEntity)] = repository;
            return repository;
        }

        public IUserRepository User => _userRepository ??= new UserRepository(_userManager, _roleManager, _context);

        public IPatientProcedureResultRepository PatientProcedureViewResult => _patientProcedureResultRepository ??= new PatientProcedureResultRepository(_context);

        public IPatientRepository Patient => _patientRepository ??= new PatientRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}