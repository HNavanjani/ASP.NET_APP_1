using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserViewModel
    {
       
        public long Id { get; set; }
        [DisplayName("User Name")]
        public String UserName { get; set; }
        [DisplayName("Password")]
        public String Password { get; set; }
        [DisplayName("First Name")]
        public String FirstName { get; set; }
        [DisplayName("Last Name")]
        public String LastName { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
    }
}