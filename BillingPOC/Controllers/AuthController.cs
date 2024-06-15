using BillingPOC.Core.DTOs.Auth;
using BillingPOC.Core.DTOs.Response;
using BillingPOC.Flow.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingPOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserFlow _userFlow;

        public AuthController(IUserFlow userFlow)
        {
            _userFlow = userFlow;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(ResponseModel<object>.Failure(errors, "Invalid model state", ErrorCode.UnknownError, 400));
            }

            var response = await _userFlow.LoginAsync(request);

            return StatusCode(response.StatusCode, response);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(ResponseModel<object>.Failure(errors, "Invalid model state", ErrorCode.UnknownError, 400));
            }

            var response = await _userFlow.RegisterUserAsync(register.Email, register.Password);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(ResponseModel<object>.Failure(errors, "Invalid model state", ErrorCode.UnknownError, 400));
            }

            var response = await _userFlow.ForgotPasswordAsync(model.Email);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(ResponseModel<object>.Failure(errors, "Invalid model state", ErrorCode.UnknownError, 400));
            }

            var response = await _userFlow.ResetPasswordAsync(model.Email, model.Token, model.NewPassword);

            return StatusCode(response.StatusCode, response);
        }
    }
}
