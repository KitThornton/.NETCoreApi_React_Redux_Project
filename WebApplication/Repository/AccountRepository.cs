using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Server.IIS.Core;
using WebApplication.Entities;

namespace WebApplication.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private IList<Account> Collection { get; set; }

        public AccountRepository()
        {
            this.Collection = InMemoryCollection;
        }
        
        #region InMemoryCollection
        private static IList<Account> InMemoryCollection { get; } = new List<Account>
        {
            new Account()
            {
                Id = 1,
                AccountType = "Domestic",
                OwnerId = 1,
                DateCreated = DateTime.Now
            },
            new Account()
            {
                Id = 2,
                AccountType = "Domestic",
                OwnerId = 1,
                DateCreated = DateTime.Now
            },
            new Account()
            {
                Id = 3,
                AccountType = "Domestic",
                OwnerId = 2,
                DateCreated = DateTime.Now
            }
        };
        #endregion Region
        
        public IEnumerable<Account> AccountsByOwner(int ownerId)
        {
            return this.Collection.Where(x => x.OwnerId.Equals(ownerId));
        }
    }
}