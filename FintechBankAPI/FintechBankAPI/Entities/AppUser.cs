using Microsoft.AspNetCore.Identity;

namespace FintechBankAPI.Entities
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public string? PublicId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string RefreshToken { get; set; } = String.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
