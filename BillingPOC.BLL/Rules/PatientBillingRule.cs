using BillingPOC.Core.Entities;
using BillingPOC.Core.ViewModels;
using NRules.Fluent.Dsl;
using NRules.RuleModel;

namespace BillingPOC.BLL.Rules
{
    [Repeatability(RuleRepeatability.NonRepeatable)]
    public class PatientBillingRule : Rule
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
                        procedure => procedure.ProcedureStatusId == 2);

            Then()
                .Do(ctx => PrintBillingInfo(patient, patientInvoice, patientProcedure));
        }

        private void PrintBillingInfo(Patient patient, PatientInvoiceResult patientInvoice,
            PatientProcedureResult patientProcedure)
        {
            Console.WriteLine($"hello");
        }
    }
}