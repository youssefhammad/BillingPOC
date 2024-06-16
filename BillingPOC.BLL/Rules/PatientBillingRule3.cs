using BillingPOC.Core.Entities;
using BillingPOC.Core.ViewModels;
using NRules.Fluent.Dsl;
using NRules.RuleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.BLL.Rules
{
    [Repeatability(RuleRepeatability.NonRepeatable)]
    public class PatientBillingRule3 : Rule
    {
        public override void Define()
        {
            Patient patient = default!;
            PatientInvoiceResult patientInvoice = default!;
            PatientProcedureResult patientProcedure = default!;

            When()
                .Match<Patient>(() => patient)
                    .Match<PatientInvoiceResult>(() => patientInvoice,
                        invoice => invoice.PatientId == patient.PatientId,
                        invoice => invoice.InvoiceStatusId == 2)
                    .Match<PatientProcedureResult>(() => patientProcedure,
                        procedure => patientInvoice.InvoiceId == procedure.InvoiceId,
                        procedure => procedure.ProcedureStatusId == 2,
                        procedure => procedure.ProcedureConfigurationId == 3);

            Then()
                .Do(ctx => UpdatePatientEntity3(patient, patientInvoice, patientProcedure));
        }

        private void UpdatePatientEntity3(Patient patient, PatientInvoiceResult patientInvoice,
            PatientProcedureResult patientProcedure)
        {
            var invoice = patient.Invoices
                .FirstOrDefault(invoice => invoice.InvoiceId == patientInvoice.InvoiceId);

            var medicalProcedure = invoice.PatientMedicalProcedures
                .FirstOrDefault(pm => pm.PatientMedicalProcedureId == patientProcedure.PatientMedicalProcedureId);

            medicalProcedure.OutOfPocketCost = patientProcedure.Price;

            medicalProcedure.ProcedureStatusId = 1;

            Console.WriteLine($"config 3");
        }
    }
}
