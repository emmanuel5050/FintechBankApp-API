using System.Security.Principal;

namespace FintechBankAPI.Entities
{
    public class Transaction
    {
        public string Id { get; set; }
       
        public double Amount { get; set; }
        public bool IsCredit { get; set; }
        public double Balance { get; set; }
        public string? Remark { get; set; }
        public DateTime DateCreated { get; set; }
        public string AccountId { get; set; }
        public virtual Account Account { get; set; } = null!;
    }
}