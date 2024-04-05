using Academy.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.ViewModels
{
    public class LoginInstructorViewModel : ILoginInstructorViewModel
    {
        public LoginInstructorViewModel(string email, string token)
        {
            Email = email;
            Token = token;

        }

        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}
