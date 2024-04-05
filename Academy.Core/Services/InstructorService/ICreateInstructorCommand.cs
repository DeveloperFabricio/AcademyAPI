using Academy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Services.InstructorService
{
    public interface ICreateInstructorCommand
    {
        int Id { get; }
        string Name { get; }
        string Email { get; }
        string Password { get; }
        SpecializationEnum Specialization { get; }
        string Availability { get; }
        string Description { get; }
        string Location { get; }
        string Role { get; }
    }
}
