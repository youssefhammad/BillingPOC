using BillingPOC.Core.DTOs.Rules;
using BillingPOC.Core.Entities;
using NRules.Fluent.Dsl;
using NRules.RuleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
                .Do(ctx => UpdateVipInvoices(invoice, patient))
                .Do(ctx => ctx.Update(invoice));
        }

        private void UpdateVipInvoices(Invoice invoice, Patient patient)
        {
            invoice.Discount = 0.1M; 

            decimal discountAmount = invoice.Charge * invoice.Discount;

            invoice.Charge -= discountAmount;

            RuleWrapper ruleWrapper = new RuleWrapper();

            ruleWrapper.ActionRules.Add(invoice);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(ruleWrapper, options);

            PatientRuleHistory patientRuleHistory = new PatientRuleHistory()
            {
                PatientId = patient.PatientId,
                RuleActionData = jsonString,
                RuleName = nameof(VIPPatientRule)
            };

            patient.PatientRuleHistories.Add(patientRuleHistory);

            Console.WriteLine($"VIP invoice updated with discount. New charge: {invoice.Charge}");
        }
    }
}
