﻿namespace FintechBankAPI.Entities
{
    public class Customer:BaseEntity
    {
        public string NinNo { get; set; }
        public string CustomerNo { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public AppUser User { get; set; }
        public virtual ICollection<Card> Cards { get; set; }

    }
}
