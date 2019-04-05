using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.Model
{

    class LoginModel
    {
        private String brugernavn;
        private String password;

        public string Brugernavn { get => brugernavn; set => brugernavn = value; }
        public string Password { get => password; set => password = value; }
    }
}
