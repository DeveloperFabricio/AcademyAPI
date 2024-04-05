using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Services.LoginService
{
    public interface ILoginInstructorCommand
    {
        int Id { get; }
        string Password { get; }
    }
}
