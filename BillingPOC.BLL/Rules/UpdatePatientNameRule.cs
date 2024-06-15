using BillingPOC.Core.Entities;
using NRules.Fluent.Dsl;
using NRules.RuleModel;


namespace BillingPOC.BLL.Rules
{
    [Repeatability(RuleRepeatability.NonRepeatable)]
    public class UpdatePatientNameRule : Rule
    {
        public override void Define()
        {
            Patient patient = default!;

            When()
                .Match<Patient>(() => patient, p => p.PatientId > 0);

            Then()
                .Do(ctx => AppendToFirstName(patient))
                .Do(ctx => ctx.Update(patient));
        }

        private void AppendToFirstName(Patient patient)
        {
            patient.FirstName += "a";
        }
    }
}
