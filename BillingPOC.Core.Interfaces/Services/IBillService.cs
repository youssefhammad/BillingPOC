using BillingPOC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.Interfaces.Services
{
    public interface IBillService
    {
        Task<object> CalculateBill(int patientId);
        Task<Patient> ManipulatePatientName(int patientId);
    }
}
