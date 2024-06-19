using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.Entities
{
    public class PatientRuleHistory
    {
        public PatientRuleHistory()
        {
            DateTime = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string RuleName { get; set; }
        public string RuleActionData { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
