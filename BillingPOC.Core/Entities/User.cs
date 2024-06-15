using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.Entities
{
    public class User : IdentityUser
    {
        public string? PhoneNumber2 { get; set; }
    }
}
