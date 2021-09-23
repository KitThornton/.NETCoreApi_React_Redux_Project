using System;
using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Repository
{
    public interface IOwnerRepository
    {
        public IEnumerable<Owner> GetAll();
        public Owner GetOwnerById(Guid id);
        public Owner GetOwnerWithDetails(Guid id);
    }
}