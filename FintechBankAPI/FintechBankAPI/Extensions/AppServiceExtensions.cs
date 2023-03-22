using FintechBankAPI.Context;
using FintechBankAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FintechBankAPI.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration _config)
        {

            services.AddDbContext<FintechApiContext>(opt =>
            {
                opt.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            });
            //services.AddScoped<ITokenService, TokenService>();
            //services.AddScoped<IValidationService, ValidationService>();

            return services;


           
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedEmail = true;

            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<FintechApiContext>()
                .AddDefaultTokenProviders();
        }
    }
}
