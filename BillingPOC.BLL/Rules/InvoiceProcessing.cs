using BillingPOC.Core.Entities;
using NRules.Fluent.Dsl;
using NRules.RuleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.BLL.Rules
{
    [Repeatability(RuleRepeatability.NonRepeatable)]
    public class InvoiceProcessing : Rule
    {
        public override void Define()
        {
            Invoice invoice = default!;
            IEnumerable<PatientMedicalProcedure> patientMedicalProcedures = default!;

            When()
                .Match<Invoice>(() => invoice, c => c.InvoiceStatusId == 2)
                .Query(() => patientMedicalProcedures,
                    q => q.Match<PatientMedicalProcedure>(a => a.InvoiceId == invoice.InvoiceId && a.ProcedureStatusId == 1)
                    .Collect().Where(pm => pm.Any()))
                .All<PatientMedicalProcedure>(a => a.InvoiceId == invoice.InvoiceId, a => a.ProcedureStatusId == 1);

            Then()
                .Do(ctx => UpdateInvoiceStatus(invoice, patientMedicalProcedures))
                .Do(ctx => ctx.Update(invoice));
        }

        private void UpdateInvoiceStatus(Invoice invoice, IEnumerable<PatientMedicalProcedure> patientMedicalProcedures)
        {
            // Summing up the OutOfPocketCost for all patient medical procedures
            var totalOutOfPocketCost = patientMedicalProcedures.Sum(pmp => pmp.OutOfPocketCost);

            invoice.Charge = totalOutOfPocketCost;

            invoice.InvoiceStatusId = 1;

            Console.WriteLine("Invoice status updated");
        }
    }
}
