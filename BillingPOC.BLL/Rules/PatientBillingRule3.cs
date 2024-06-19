using BillingPOC.Core.DTOs.Rules;
using BillingPOC.Core.Entities;
using BillingPOC.Core.ViewModels;
using NRules.Fluent.Dsl;
using NRules.RuleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
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
                .Do(ctx => UpdatePatientEntity3(patientProcedureView, medicalProcedure, patient))
                .Do(ctx => ctx.Update(medicalProcedure));
        }

        private void UpdatePatientEntity3(PatientProcedureResult patientProcedure, 
            PatientMedicalProcedure medicalProcedure, Patient patient)
        {
            
            medicalProcedure.OutOfPocketCost = patientProcedure.Price;

            medicalProcedure.ProcedureStatusId = 1;

            RuleWrapper ruleWrapper = new RuleWrapper();

            ruleWrapper.ActionRules.Add(patientProcedure);
            ruleWrapper.ActionRules.Add(patient);
            ruleWrapper.ActionRules.Add(medicalProcedure);

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
                RuleName = nameof(PatientBillingRule3)
            };

            patient.PatientRuleHistories.Add(patientRuleHistory);

            Console.WriteLine($"config 3");
        }
    }
}
