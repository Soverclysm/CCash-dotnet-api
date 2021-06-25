using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCash_dotnet_api {
    public class CCashClient: Communication {
        public string Username { get; set; }
        public string Password { get; set; }
        private string _auth;
        public CCashClient(string username, string password) {
            _auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
        }
    }
}
