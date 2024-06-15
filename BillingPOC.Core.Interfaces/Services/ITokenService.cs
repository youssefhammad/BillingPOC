using BillingPOC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user, IList<string> roles);
    }
}
