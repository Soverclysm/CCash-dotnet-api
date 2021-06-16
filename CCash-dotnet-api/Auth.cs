using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCash_dotnet_api {
    public struct Auth {
        public string username;
        public string password;
        public Auth(string username, string password) {
            this.username = username;
            this.password = password;
        }
    }
}
