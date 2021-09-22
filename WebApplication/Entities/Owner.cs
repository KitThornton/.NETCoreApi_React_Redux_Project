using System;

namespace WebApplication.Entities
{
    public class Owner
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}