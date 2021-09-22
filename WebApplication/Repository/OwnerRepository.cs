using System;
using System.Collections.Generic;
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

        private static IList<Owner> InMemoryCollection { get; } = new List<Owner>
        {
            new Owner()
            {
                DateOfBirth = new DateTime(1996, 10, 20),
                id = 2,
                Name = "Jonty",
                Address = "Home"
            },
            new Owner()
            {
                id = 1, Name = "Kit",
                Address = "Home",
                DateOfBirth = new DateTime(1996, 02, 20)
            }
        };
            
        public IEnumerable<Owner> GetAll()
        {
            return this.Collection;
        }
    }
}