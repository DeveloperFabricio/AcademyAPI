using Academy.Core.Enums;
using Academy.Core.Services.InstructorService;
using MediatR;

namespace Academy.Application.Commands.CreateInstructorCommand
{
    public class CreateInstructorCommand : IRequest<Unit>, ICreateInstructorCommand
    {
        public CreateInstructorCommand(int id,
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
