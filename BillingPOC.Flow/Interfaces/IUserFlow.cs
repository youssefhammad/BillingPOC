using BillingPOC.Core.DTOs.Auth;
using BillingPOC.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Flow.Interfaces
{
    public interface IUserFlow
    {
        Task<ResponseModel<object>> LoginAsync(LoginModel request);
        Task<ResponseModel<object>> RegisterUserAsync(string email, string password);
        Task<ResponseModel<object>> ForgotPasswordAsync(string email);
        Task<ResponseModel<object>> ResetPasswordAsync(string email, string token, string newPassword);
    }
}
