using BillingPOC.Core.DTOs.Auth;
using BillingPOC.Core.DTOs.Response;
using BillingPOC.Core.Interfaces.Repositories;
using BillingPOC.Core.Interfaces.Services;
using BillingPOC.Flow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Flow.Implmentations
{
    public class UserFlow : IUserFlow
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UserFlow(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel<object>> ForgotPasswordAsync(string email)
        {
            return await _userService.ForgotPasswordAsync(email);
        }

        public async Task<ResponseModel<object>> LoginAsync(LoginModel request)
        {
            return await _userService.LoginAsync(request);
        }

        public async Task<ResponseModel<object>> RegisterUserAsync(string email, string password)
        {
            return await _userService.RegisterUserAsync(email, password);
        }

        public async Task<ResponseModel<object>> ResetPasswordAsync(string email, string token, string newPassword)
        {
            return await _userService.ResetPasswordAsync(email, token, newPassword);
        }
    }
}
