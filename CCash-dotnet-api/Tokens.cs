using System.Collections.Generic;
using System.IO;

namespace CCash_dotnet_api {
    public class Tokens {
        public Dictionary<string, string> TokensDictionary = new();
        public Tokens() {
            string DirectoryName = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName+@"\dictionary_population.txt";
            foreach (string s in File.ReadAllLines(DirectoryName)) {
                TokensDictionary.Add(s.Split(':')[0], s.Split(':')[1]);
            }
        }
    }
}
