using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternRegister.Models.InternsModel
{
    public class Intern
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool Sponsorship { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}