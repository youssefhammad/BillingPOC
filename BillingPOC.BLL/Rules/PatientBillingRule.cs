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
            IEnumerable<PatientInvoiceResult> patientInvoices = default!;
            IEnumerable<PatientProcedureResult> patientProcedures = default!;

            When()
                .Match<Patient>(() => patient)
                .Query(() => patientInvoices, q => q
                    .Match<PatientInvoiceResult>(
                        invoice => invoice.PatientId == patient.PatientId,
                        invoice => invoice.InvoiceStatusId == 2)
                    .Collect()
                    .Where(invoices => invoices.Any()))
                .Query(() => patientProcedures, q => q
                    .Match<PatientProcedureResult>(
                        procedure => patientInvoices.Select(i => i.InvoiceId).Contains(procedure.InvoiceId),
                        procedure => procedure.ProcedureStatusId == 2) 
                    .Collect()
                    .Where(procedures => procedures.Any()));

            Then()
                .Do(ctx => PrintBillingInfo(patient, patientInvoices, patientProcedures));
        }

        private void PrintBillingInfo(Patient patient, IEnumerable<PatientInvoiceResult> patientInvoices, 
            IEnumerable<PatientProcedureResult> patientProcedures)
        {
            Console.WriteLine($"hello");
        }
    }
}