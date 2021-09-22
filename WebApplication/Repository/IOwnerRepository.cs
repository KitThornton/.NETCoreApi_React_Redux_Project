using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Repository
{
    public interface IOwnerRepository
    {
        public IEnumerable<Owner> GetAll();
    }
}