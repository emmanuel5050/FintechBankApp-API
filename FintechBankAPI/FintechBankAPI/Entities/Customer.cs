namespace FintechBankAPI.Entities
{
    public class Customer:BaseEntity
    {
        public string NinNo { get; set; }
        public Address Address { get; set; }
        public DateTime Dob { get; set; }
        public AppUser User { get; set; }
        public virtual ICollection<Card> Cards { get; set; }

    }
}
