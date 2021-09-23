using System;
using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Repository
{
    public interface IOwnerRepository
    {
        public IEnumerable<Owner> GetAllOwners();
        public Owner GetOwnerById(int id);
        public OwnerExtended GetOwnerWithDetails(int id);
    }
}