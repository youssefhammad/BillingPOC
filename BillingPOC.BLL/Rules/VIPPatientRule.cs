using BillingPOC.Core.Entities;
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
    public class VIPPatientRule : Rule
    {
        public override void Define()
        {
            Invoice invoice = default!;
            Patient patient = default!;

            When()
                .Match<Patient>(() => patient, c => c.IsVIP)
                .Match<Invoice>(() => invoice,
                i => i.PatientId == patient.PatientId && i.InvoiceStatusId == 1);

            Then()
                .Do(ctx => UpdateVipInvoices(invoice))
                .Do(ctx => ctx.Update(invoice));
        }

        private void UpdateVipInvoices(Invoice invoice)
        {
            invoice.Discount = 0.1M; 

            decimal discountAmount = invoice.Charge * invoice.Discount;

            invoice.Charge -= discountAmount;

            Console.WriteLine($"VIP invoice updated with discount. New charge: {invoice.Charge}");
        }
    }
}
