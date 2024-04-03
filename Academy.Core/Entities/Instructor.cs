using Academy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Entities
{
    public class Instructor
    {
        public Instructor(int id,
            string name,
            string email,
            string password,
            SpecializationEnum specialization,
            string availability,
            string description,
            string location,
            string role)

        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Specialization = specialization;
            Availability = availability;
            Description = description;
            Location = location;
            Role = role;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public SpecializationEnum Specialization { get; set; }
        public string Availability { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Role { get; set; }
    }
}
