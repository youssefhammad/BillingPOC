using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.Entities
{
    public class InsuranceCompany
    {
        [Key]
        public int InsuranceCompanyId { get; set; }
        public string Name { get; set; }

        public ICollection<Plan> Plans { get; set; }
    }
}
