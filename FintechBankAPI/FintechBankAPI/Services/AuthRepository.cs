using FintechBankAPI.Context;
using FintechBankAPI.DTOs;
using FintechBankAPI.Interfaces;
using FintechBankAPI.Models;

namespace FintechBankAPI.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly FintechApiContext _context;
        private readonly List<string> OtherCurrencies = new() { "EUR", "USD", "GBP" };
        public AuthRepository(IAuthRepository authRepository, FintechApiContext context)
        {
            _authRepository = authRepository;
            _context = context;
        }

        public Task<Response<string>> Register(RegisterDTO user)
        {
           
        }
        public Task<object> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            throw new NotImplementedException();
        }

        public Task<object> ForgottenPassword(ResetPasswordDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> Login(LoginDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> RefreshToken()
        {
            throw new NotImplementedException();
        }

    

        public Task<object> ResetPasswordAsync(UpdatePasswordDTO resetPasswordDTO)
        {
            throw new NotImplementedException();
        }
    }
}
