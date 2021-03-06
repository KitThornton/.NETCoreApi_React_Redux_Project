using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Entities
{
    public class OwnerExtended 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public IEnumerable<Account> Accounts { get; set; }

        public OwnerExtended(Owner owner, IEnumerable<Account> accounts)
        {
            Id = owner.Id;
            Name = owner.Name;
            DateOfBirth = owner.DateOfBirth;
            Address = owner.Address;
            Accounts = accounts;
        }

        public OwnerExtended()
        {
            
        }
    }
}