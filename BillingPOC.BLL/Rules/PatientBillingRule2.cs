using BillingPOC.Core.Entities;
using BillingPOC.Core.ViewModels;
using NRules.Fluent.Dsl;
using NRules.RuleModel;

namespace BillingPOC.BLL.Rules
{
    [Repeatability(RuleRepeatability.NonRepeatable)]
    public class PatientBillingRule2 : Rule
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
                                   procedureResult => procedureResult.ProcedureConfigurationId == 2));

            Then()
           .Do(ctx => UpdatePatientEntity2(patient, patientProcedureView, medicalProcedure))
           .Do(ctx => ctx.Update(medicalProcedure));
        }

        private void UpdatePatientEntity2(Patient patient,
            PatientProcedureResult patientProcedure, PatientMedicalProcedure medicalProcedure)
        {

            decimal outOfPocketCost = patient.CoInsurance * patientProcedure.Price;

            medicalProcedure.OutOfPocketCost = outOfPocketCost;

            decimal coveredAmount = patientProcedure.Price - outOfPocketCost;

            medicalProcedure.CoveredAmount = coveredAmount;

            medicalProcedure.ProcedureStatusId = 1;

            Console.WriteLine($"config 2");
        }

    }
}