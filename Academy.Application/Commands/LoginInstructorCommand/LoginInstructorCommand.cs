using Academy.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Commands.LoginInstructorCommand
{
    public class LoginInstructorCommand : IRequest<LoginInstructorViewModel>
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }

}
