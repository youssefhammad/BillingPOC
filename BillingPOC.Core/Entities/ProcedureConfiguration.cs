using System.ComponentModel.DataAnnotations;

namespace BillingPOC.Core.Entities
{
    public class ProcedureConfiguration
    {
        [Key]
        public int ProcedureConfigurationId { get; set; }
        public string ConfigurationName { get; set; }

        public ICollection<ProcedurePlanConfiguration> ProcedurePlanConfigurations { get; set; }
    }
}
