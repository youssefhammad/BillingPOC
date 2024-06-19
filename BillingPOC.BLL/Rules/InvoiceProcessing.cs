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
            Invoice invoice= default!;
            IEnumerable<PatientMedicalProcedure> patientMedicalProcedures = default!;

            When()
                .Match<Invoice>(() => invoice, c => c.InvoiceStatusId == 2)
                .All<PatientMedicalProcedure>(a => a.InvoiceId == invoice.InvoiceId, a => a.ProcedureStatusId == 1);

            Then()
                .Do(ctx => UpdateInvoiceStatus(invoice));
        }

        private void UpdateInvoiceStatus(Invoice invoice)
        {
            invoice.InvoiceStatusId = 1;

            Console.WriteLine("Invoice status updated");
        }
    }
}
