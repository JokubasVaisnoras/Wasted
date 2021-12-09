using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace wasted_app.Tables
{
    public class RegUserTable
    {
        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Newsletter { get; set; }
    }

    public class Newsletter
    {
        [Key]
        public Guid NewsId { get; set; }
        public string Name { get; set; }

        public Guid UserId { get; set; }
    }
}
