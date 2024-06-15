using BillingPOC.Core.DTOs.Auth;
using BillingPOC.Core.DTOs.Response;
using BillingPOC.Core.Entities;
using BillingPOC.Core.Enums;
using BillingPOC.Core.Interfaces.Repositories;
using BillingPOC.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.BLL.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public UserService(IUnitOfWork unitOfWork, ITokenService tokenService,
            IConfiguration configuration, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<ResponseModel<object>> LoginAsync(LoginModel request)
        {
            var user = await _unitOfWork.User.FindByEmailAsync(request.Email);
            if (user == null || !await _unitOfWork.User.CheckPasswordAsync(user, request.Password))
            {
                return ResponseModel<object>.Failure(new[] { "Invalid email or password" }, "Authorization failed", ErrorCode.UnknownError, 401);
            }

            var roles = await _unitOfWork.User.GetRolesAsync(user);
            var token = _tokenService.GenerateToken(user, roles);
            return ResponseModel<object>.Success(new { Token = token }, "Login successful", 200);
        }

        public async Task<ResponseModel<object>> RegisterUserAsync(string email, string password)
        {
            var user = new User { UserName = email, Email = email };
            var result = await _unitOfWork.User.CreateUserAsync(user, password);

            if (result.Succeeded)
            {
                var roleResult = await _unitOfWork.User.AddToRoleAsync(user, EnRoles.Administrator.ToString());

                if (roleResult.Succeeded)
                {
                    return ResponseModel<object>.Success(null, "User registered and role assigned successfully", 201);
                }

                // Role assignment failed, delete the user
                _unitOfWork.User.Remove(user);
                await _unitOfWork.CompleteAsync();

                var roleErrors = roleResult.Errors.Select(e => e.Description);
                return ResponseModel<object>.Failure(roleErrors, "Role assignment failed, user deleted for consistency", ErrorCode.UnknownError, 400);
            }

            var errors = result.Errors.Select(e => e.Description);
            return ResponseModel<object>.Failure(errors, "Registration failed", ErrorCode.UnknownError, 400);
        }

        public async Task<ResponseModel<object>> ForgotPasswordAsync(string email)
        {
            var user = await _unitOfWork.User.FindByEmailAsync(email);
            if (user == null)
            {
                return ResponseModel<object>.Failure(new[] { "User not found" }, "Forgot password failed", ErrorCode.UnknownError, 404);
            }

            var token = await _unitOfWork.User.GeneratePasswordResetTokenAsync(user);
            var clientUrl = _configuration["ClientUrl"];
            var callbackUrl = $"{clientUrl}/reset-password?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(email)}";

            // Send the callback URL via email
            await _emailService.SendEmailAsync(email, "Reset Password", $"Please reset your password by clicking here: <a href=\"{callbackUrl}\">link</a>");

            return ResponseModel<object>.Success(null, "Password reset token generated and email sent successfully", 200);
        }

        public async Task<ResponseModel<object>> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _unitOfWork.User.FindByEmailAsync(email);
            if (user == null)
            {
                return ResponseModel<object>.Failure(new[] { "User not found" }, "Reset password failed", ErrorCode.UnknownError, 404);
            }

            var result = await _unitOfWork.User.ResetPasswordAsync(user, token, newPassword);

            if (result.Succeeded)
            {
                return ResponseModel<object>.Success(null, "Password reset successfully", 200);
            }

            var errors = result.Errors.Select(e => e.Description);
            return ResponseModel<object>.Failure(errors, "Password reset failed", ErrorCode.UnknownError, 400);
        }
    }
}
