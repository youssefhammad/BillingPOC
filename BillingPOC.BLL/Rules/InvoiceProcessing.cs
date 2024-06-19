using BillingPOC.Core.DTOs.Rules;
using BillingPOC.Core.Entities;
using NRules.Fluent.Dsl;
using NRules.RuleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace BillingPOC.BLL.Rules
{
    [Repeatability(RuleRepeatability.NonRepeatable)]
    public class InvoiceProcessing : Rule
    {
        public override void Define()
        {
            Invoice invoice = default!;
            Patient patient = default!;
            IEnumerable<PatientMedicalProcedure> patientMedicalProcedures = default!;

            When()
                //.Match<Patient>(() => patient)
                .Match<Invoice>(() => invoice, c => c.InvoiceStatusId == 2)
                .Match<Patient>(() => patient, p => p.PatientId == invoice.PatientId)
                .Query(() => patientMedicalProcedures,
                    q => q.Match<PatientMedicalProcedure>(a => a.InvoiceId == invoice.InvoiceId && a.ProcedureStatusId == 1)
                    .Collect().Where(pm => pm.Any()))
                .All<PatientMedicalProcedure>(a => a.InvoiceId == invoice.InvoiceId, a => a.ProcedureStatusId == 1);

            Then()
                .Do(ctx => UpdateInvoiceStatus(invoice, patientMedicalProcedures, patient))
                .Do(ctx => ctx.Update(invoice));
        }

        private void UpdateInvoiceStatus(Invoice invoice, IEnumerable<PatientMedicalProcedure> patientMedicalProcedures,
            Patient patient)
        {
            // Summing up the OutOfPocketCost for all patient medical procedures
            var totalOutOfPocketCost = patientMedicalProcedures.Sum(pmp => pmp.OutOfPocketCost);

            invoice.Charge = totalOutOfPocketCost;

            invoice.InvoiceStatusId = 1;

            RuleWrapper ruleWrapper = new RuleWrapper();

            ruleWrapper.ActionRules.Add(invoice);
            ruleWrapper.ActionRules.Add(patient);
            ruleWrapper.ActionRules.Add(patientMedicalProcedures);

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
                RuleName = nameof(InvoiceProcessing)
            };

            patient.PatientRuleHistories.Add(patientRuleHistory);

            Console.WriteLine("Invoice status updated");
        }
    }
}
