using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKapp.BL
{
    class Users
    {
        public Users(string userName, string passwords, string roles)
        {
            this.userName = userName;
            this.passwords = passwords;
            this.roles = roles;

        }
        public string userName;
        public string passwords;
        public string roles;
    }
}
