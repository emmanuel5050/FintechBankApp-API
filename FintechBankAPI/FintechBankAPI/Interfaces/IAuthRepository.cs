using FintechBankAPI.DTOs;
using FintechBankAPI.Models;

namespace FintechBankAPI.Interfaces
{
    public interface IAuthRepository
    {
        Task<Response<string>> Login(LoginDTO model);
        Task<Response<string>> Register(RegisterDTO user);
        Task<Response<string>> RefreshToken();
        public Task<object> ChangePassword(ChangePasswordDTO changePasswordDTO);
        public Task<object> ResetPasswordAsync(UpdatePasswordDTO resetPasswordDTO);
        public Task<object> ForgottenPassword(ResetPasswordDTO model);
    }
}
