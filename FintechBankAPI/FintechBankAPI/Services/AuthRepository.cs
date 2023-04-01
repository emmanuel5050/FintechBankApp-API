using AutoMapper;
using FintechBankAPI.ApplicationConfig;
using FintechBankAPI.Context;
using FintechBankAPI.DTOs;
using FintechBankAPI.Entities;
using FintechBankAPI.Interfaces;
using FintechBankAPI.Models;
using FintechBankAPI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

namespace FintechBankAPI.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IValidationService _validationService;
        private readonly AppConfig _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly FintechApiContext _context;
        private readonly List<string> OtherCurrencies = new() { "EUR", "USD", "GBP" };
        private readonly IMapper _mapper;
        public AuthRepository(FintechApiContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContext,
            RoleManager<IdentityRole> roleManager, IValidationService validate, IOptions<AppConfig> config, IMapper mapper)
        {
            _validationService = validate;
            _context = context;
            _userManager = userManager;
            _httpContext = httpContext;
            _roleManager = roleManager;
            _config = config.Value;
            _mapper= mapper;
        }

        public async Task<Response> Register(RegisterDTO user)
        {
            var mapInitializer = new MapInitializer();
            var errors = _validationService.ValidateCustomer(user);
            if (errors.Any()) return new ErrorResponse { Message = $"Unable to register customer: {errors.FirstOrDefault().Value}", Content = errors };
            var existingNin = await _context.Customers.AnyAsync(c => c.NinNo == user.NinNo);
            if(existingNin) return new ErrorResponse { Message="Customer already exist"};
            var newUser = _mapper.Map<AppUser>(user); //mapInitializer.regMapper.Map<RegisterDTO, AppUser>(user);
            var createIdentityUser= await _userManager.CreateAsync(newUser,user.Password);
            var roles = await _roleManager.Roles.ToListAsync();
            if(roles.Count==0)  await _roleManager.CreateAsync(new IdentityRole { Name = "Customer" });
            if (createIdentityUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "Customer");
                var newCustomer = _mapper.Map<Customer>(user); //mapInitializer.regMapper.Map<RegisterDTO, Customer>(user);
                var currencies = await _context.Currencies.ToListAsync();
                if (currencies.Count == 0)
                {
                    await _context.Currencies.AddAsync(new Currency { Id = "1", CurrencyCode = _config.DefaultCurrency, CurrencyName = "Naira" });
                    await _context.SaveChangesAsync();
                }
                var currency = await _context.Currencies.FirstOrDefaultAsync(x => x.CurrencyCode == _config.DefaultCurrency);
                var lastCustomer = await _context.Customers.OrderByDescending(x => x.CreatedAt).FirstOrDefaultAsync();
                var lastAccount = await _context.Accounts.OrderByDescending(x => x.CreatedAt).FirstOrDefaultAsync();
                int customerNo;
                int accountNo;
                Random random = new();
                if (lastCustomer == null) //to cater for first customer creation
                {
                    customerNo = random.Next(1000000000, 2000000000);
                }
                else
                {
                    customerNo = Convert.ToInt32(lastCustomer.CustomerNo) + 1;
                }
                if (lastAccount == null) //to cater for first account creation
                {
                    accountNo = random.Next(300000000, 400000000);
                }
                else
                {
                    accountNo = Convert.ToInt32(lastAccount.AccountNumber) + 1;
                }
                await _context.Customers.AddAsync(newCustomer);
                int CustSaved = await _context.SaveChangesAsync();
                if (CustSaved < 0) return new ErrorResponse { Message = "Unable to create customer" };
                Account acct = new()
                {
                    AccountNumber = accountNo.ToString(),
                    Balance = 0,
                    CurrencyId = currency.Id,
                    CustomerId = newCustomer.Id,
                    CreatedAt = DateTime.UtcNow
                };
                await _context.Accounts.AddAsync(acct);
                int accountSaved = await _context.SaveChangesAsync();
                if (accountSaved <= 0)
                {
                    _context.Customers.Remove(newCustomer);
                    await _context.SaveChangesAsync();
                    return new ErrorResponse
                    {
                        Message = "Unable to create account for customer."
                    };

                }


                return new SuccessResponse
                {
                    Success = true,
                    Status = (int)HttpStatusCode.Created,
                    Message = "Customer Created Successfully",
                    Content = new CreateCustomerResponse { AccountNumber = accountNo.ToString(), CustomerNumber = customerNo.ToString() }
                };
            };
            return new ErrorResponse { Message = createIdentityUser.Errors.FirstOrDefault().Description, Status = (int)HttpStatusCode.UnprocessableEntity };

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
