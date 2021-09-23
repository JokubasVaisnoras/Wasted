using System;
using System.Collections.Generic;
using System.Text;

namespace wasted_app.Tables
{
    public class RegUserTable
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
