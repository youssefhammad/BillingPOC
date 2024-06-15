using BillingPOC.Core.Entities;
using BillingPOC.Core.Interfaces.Services;
using BillingPOC.Flow.Interfaces;

namespace BillingPOC.Flow.Implmentations
{
    public class BillFlow : IBillFlow
    {
        private readonly IBillService _billService;

        public BillFlow(IBillService billService)
        {
            _billService = billService;
        }

        public async Task<object> CalculateBill(int patientId)
        {
            return await _billService.CalculateBill(patientId);
        }

        public async Task<Patient> ManipulatePatientName(int patientId)
        {
            return await _billService.ManipulatePatientName(patientId);
        }
    }
}
