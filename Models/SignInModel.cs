using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filter_App.Models
{
    public class SignInModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Cookie { get; set; }
    }
}