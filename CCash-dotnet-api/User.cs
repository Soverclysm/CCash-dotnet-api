using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCash_dotnet_api {
    public struct User {
        public string username;
        public string password;
        public User(string username="", string password="") {
            this.username = username;
            this.password = password;
        }
    }
}
