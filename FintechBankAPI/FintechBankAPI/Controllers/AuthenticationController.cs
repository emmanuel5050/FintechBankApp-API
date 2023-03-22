using FintechBankAPI.DTOs;
using FintechBankAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FintechBankAPI.Controllers
{
    public class AuthenticationController : RootController
    {
        private readonly IAuthRepository _authRepository;
        public AuthenticationController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO user)
        {
            var register = await _authRepository.Register(user);
            if (register.Success == true) return Ok(register);
            return BadRequest(register);
        }
    }
}
