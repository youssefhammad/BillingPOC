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
            Invoice invoice = default!;
            PatientInvoiceResult patientInvoiceView = default!;
            PatientProcedureResult patientProcedureView = default!;
            PatientMedicalProcedure medicalProcedure = default!;

            When()
                .Match<Patient>(() => patient)
                    .Match<Invoice>(() => invoice,
                        inv => inv.PatientId == patient.PatientId)
                    .Query(() => patientInvoiceView,
                        q => q.Match<PatientInvoiceResult>()
                            .Where(invoiceResult => invoiceResult.InvoiceId == invoice.InvoiceId,
                                   invoiceResult => invoiceResult.InvoiceStatusId == 2))
                    .Match<PatientMedicalProcedure>(() => medicalProcedure,
                        proc => proc.InvoiceId == patientInvoiceView.InvoiceId &&
                                proc.ProcedureStatusId == 2) 
                    .Query(() => patientProcedureView,
                        q => q.Match<PatientProcedureResult>()
                            .Where(procedureResult => procedureResult.PatientMedicalProcedureId == medicalProcedure.PatientMedicalProcedureId,
                                   procedureResult => procedureResult.ProcedureConfigurationId == 3));

            Then()
                .Do(ctx => UpdatePatientEntity3(patientProcedureView, medicalProcedure));
        }

        private void UpdatePatientEntity3(PatientProcedureResult patientProcedure, PatientMedicalProcedure medicalProcedure)
        {
            
            medicalProcedure.OutOfPocketCost = patientProcedure.Price;

            medicalProcedure.ProcedureStatusId = 1;

            Console.WriteLine($"config 3");
        }
    }
}
