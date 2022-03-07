using System;
using System.Collections.Generic;
using System.Text;

namespace See4U.Tables
{
    public class RegisterUserTab
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName {get; set; }

    }
}
