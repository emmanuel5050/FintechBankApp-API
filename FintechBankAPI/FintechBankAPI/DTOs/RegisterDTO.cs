namespace FintechBankAPI.DTOs
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NinNo { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Gender { get; set; }

        public bool IsActive { get; set; } = false;

    }
}
