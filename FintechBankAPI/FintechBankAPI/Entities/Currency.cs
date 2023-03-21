using System.Security.Principal;

namespace FintechBankAPI.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string? CurrencyName { get; set; }
        public string CurrencyCode { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}