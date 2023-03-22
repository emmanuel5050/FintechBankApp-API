using FintechBankAPI.DTOs;

namespace FintechBankAPI.Interfaces
{
    public interface IValidationService
    {
        IDictionary<string, string> ValidateCustomer(RegisterDTO registerDTO);
    }
}
