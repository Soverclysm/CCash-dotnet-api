using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;

namespace CCash_dotnet_api {
    class Program {

        static void Main() {
            Communication comms = new();
            comms.current_user = new();
            string test_input = comms.SendRequest("Ping").Result;
            Console.WriteLine(test_input);
            Console.Read();
        }

    }
}