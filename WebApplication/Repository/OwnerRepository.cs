using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Controllers;
using WebApplication.Entities;

namespace WebApplication.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        public OwnerRepository()
        {
            this.Collection = InMemoryCollection;
        }

        private IList<Owner> Collection { get; set; }

        #region InMemoryCollection
        private static IList<Owner> InMemoryCollection { get; } = new List<Owner>
        {
            new Owner()
            {
                DateOfBirth = new DateTime(1996, 10, 20),
                Id = 1,
                Name = "Jonty",
                Address = "Home"
            },
            new Owner()
            {
                Id = 2, 
                Name = "Kit",
                Address = "Home",
                DateOfBirth = new DateTime(1996, 02, 20)
            }
        };
        #endregion Region
        
        public IEnumerable<Owner> GetAllOwners()
        {
            return this.Collection;
        }

        public Owner GetOwnerById(int id)
        {
            return this.Collection.First(x => x.Id.Equals(id));
        }

        public OwnerExtended GetOwnerWithDetails(int id)
        {
            return new OwnerExtended();
        }
    }
}