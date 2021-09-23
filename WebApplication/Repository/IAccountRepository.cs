using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Repository
{
    public interface IAccountRepository
    {
        public IEnumerable<Account> AccountsByOwner(int ownerId);
    }
}