using BillingPOC.Flow.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingPOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillFlow _billFlow;

        public BillController(IBillFlow billFlow)
        {
            _billFlow = billFlow;
        }

        [HttpGet("calculate-bill")]
        public async Task<IActionResult> CalulateBill(int patientId)
        {
            var data = await _billFlow.CalculateBill(patientId);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> ManipulatePatientName(int patientId)
        {
            var patient = await _billFlow.ManipulatePatientName(patientId);

            return Ok(patient);
        }
    }
}
