using FintechBankAPI.Context;
using FintechBankAPI.DTOs;
using FintechBankAPI.Entities;
using FintechBankAPI.Interfaces;
using FintechBankAPI.Models;
using FintechBankAPI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FintechBankAPI.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IValidationService _validationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly FintechApiContext _context;
        private readonly List<string> OtherCurrencies = new() { "EUR", "USD", "GBP" };
        public AuthRepository(FintechApiContext context,UserManager<AppUser> userManager, IHttpContextAccessor httpContext,
            RoleManager<IdentityRole> roleManager, IValidationService validate)
        {
            _validationService = validate;
            _context = context;
            _userManager = userManager;
            _httpContext = httpContext;
            _roleManager = roleManager;
        }

        public async Task<Response> Register(RegisterDTO user)
        {
            var mapInitializer = new MapInitializer();
            var errors = _validationService.ValidateCustomer(user);
            if (errors.Any()) return new ErrorResponse { Message = $"Unable to register customer: {errors.FirstOrDefault().Value}", Content = errors };
            var newUser = mapInitializer.regMapper.Map<RegisterDTO, AppUser>(user);
            var createIdentityUser= await _userManager.CreateAsync(newUser,user.Password);
            var roles = await _roleManager.Roles.ToListAsync();
            if(roles.Count==0)  await _roleManager.CreateAsync(new IdentityRole { Name = "Customer" });
            if (createIdentityUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "Customer");
                return new SuccessResponse { Success = true };
            }
            return new ErrorResponse { Message = createIdentityUser.Errors.FirstOrDefault().ToString(), Status = 400 };
                
           


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
