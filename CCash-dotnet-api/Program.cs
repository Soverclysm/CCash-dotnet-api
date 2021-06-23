using System;

namespace CCash_dotnet_api {
    class Program {

        static void Main() {
            Communication comms = new();
            string test_input = comms.SendRequest("Ping").Result;
            Console.WriteLine(test_input);
            Console.Read();
        }

    }
}