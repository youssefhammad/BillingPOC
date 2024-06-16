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
using BillingPOC.Core.ViewModels;
using System.Reflection;

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
            //repository.Load(x => x.From(typeof(UpdatePatientNameRule).Assembly));
            //repository.Load(x => x.From(typeof(PatientBillingRule).Assembly));

            repository.Load(x => x.From(Assembly.GetExecutingAssembly()));

            // Compile the rules
            _sessionFactory = repository.Compile();
        }

        public async Task<object> CalculateBill(int patientId)
        {
            Patient patient =  await _unitOfWork.Patient.GetByIdAsync(patientId);
            
            IEnumerable<PatientProcedureResult> patientprocedures = await _unitOfWork.PatientProcedureViewResult.GetPatientProcedureResultsAsync(patientId);

            IEnumerable<PatientInvoiceResult> patientInvoice = await _unitOfWork.PatientInvoiceResult.GetPatientInvoiceResultsAsync(patientId);
            var session = _sessionFactory.CreateSession();

            // Insert facts into the session
            session.Insert(patient);
            session.InsertAll(patientprocedures);
            session.InsertAll(patientInvoice);

            // Fire the rules
            session.Fire();

            return new
            {
                Patient = patient,
                PatientProcedures = patientprocedures,
                PatientInvoices = patientInvoice
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
