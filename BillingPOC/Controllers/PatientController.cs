using BillingPOC.Core.DTOs.Invoices;
using BillingPOC.Core.Entities;
using BillingPOC.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BillingPOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _unitOfWork.Patient.GetRelatedPatientWithPlan();

            return Ok(patients);
        }

        [HttpGet("get-all-mediacl-procedures")]
        public async Task<IActionResult> GetAllMedicalProcedures()
        {
            var medicalProcedures = await _unitOfWork.MedicalProcedures.GetAllAsync();

            return Ok(medicalProcedures);
        }

        [HttpPost("add-invoice")]
        public async Task<IActionResult> AddNewInvoice(InvoiceDto invoiceDto)
        {
            List<PatientMedicalProcedure> patientMedicalProcedures = new List<PatientMedicalProcedure>();
            foreach (var medicalProcedure in invoiceDto.PatientMedicalProcedures)
            {
                PatientMedicalProcedure patientMedicalProcedure = new PatientMedicalProcedure();

                patientMedicalProcedure.ProcedureDate = medicalProcedure.ProcedureDate;
                patientMedicalProcedure.MedicalProcedureId = medicalProcedure.MedicalProcedureId;
                patientMedicalProcedure.ProcedureStatusId = 2;

                patientMedicalProcedures.Add(patientMedicalProcedure);

            }

            Invoice invoice = new Invoice()
            {
                PatientId = invoiceDto.PatientId,
                InvoiceStatusId = 2,
                DateTime = DateTime.Now,
                PatientMedicalProcedures = patientMedicalProcedures
            };


            await _unitOfWork.Invoice.AddAsync(invoice);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

    }
}
