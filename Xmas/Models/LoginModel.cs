using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xmas.Models
{
    public class LoginModel
    {
        private string _email, _password;

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }
    }
}
