using BillingPOC.Core.Entities;
using BillingPOC.Core.Interfaces.Repositories;
using BillingPOC.Core.Interfaces.Services;
using NRules.Fluent;
using NRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingPOC.BLL.Rules;

namespace BillingPOC.BLL.Implementations
{
    public class BillService : IBillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISessionFactory _sessionFactory;

        public BillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            // Define the rule repository
            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(UpdatePatientNameRule).Assembly));

            // Compile the rules
            _sessionFactory = repository.Compile();
        }

        public async Task<object> CalculateBill(int patientId)
        {
            var patient =  await _unitOfWork.Patient.GetByIdAsync(patientId);
            
            var patientprocedures = await _unitOfWork.PatientProcedureViewResult.GetPatientProcedureResultsAsync(patientId);


            return new
            {
                Patient = patient,
                Patientprocedures = patientprocedures,
            };
        }

        public async Task<Patient> ManipulatePatientName(int patientId)
        {
            Patient patient = await _unitOfWork.Patient.GetByIdAsync(patientId);

            if (patient != null)
            {
                // Create a rules session
                var session = _sessionFactory.CreateSession();

                // Insert the patient into the session
                session.Insert(patient);

                // Fire the rules
                session.Fire();

                await _unitOfWork.CompleteAsync();
            }

            return patient;
        }
    }
}
