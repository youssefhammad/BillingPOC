using BillingPOC.Core.DTOs.Rules;
using BillingPOC.Core.Entities;
using BillingPOC.Core.ViewModels;
using NRules.Fluent.Dsl;
using NRules.RuleModel;
using System.Text.Json.Serialization;
using System.Text.Json;

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
                RuleName = nameof(PatientBillingRule2)
            };

            patient.PatientRuleHistories.Add(patientRuleHistory);

            Console.WriteLine($"config 2");
        }

    }
}