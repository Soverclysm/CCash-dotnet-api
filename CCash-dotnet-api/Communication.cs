using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace CCash_dotnet_api {
    /*public class Communication {

        private readonly HttpClient http_client = new();
        public User current_user = new();
        public Dictionary<string, string> tokens_dictionary = new();
        public string connected_webserver = "https://wtfisthis.tech/BankF/";

        // this is cancer, how to improve?
        public string info_directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(
            Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + @"\dictionary_population.txt";

        public Communication() {
            foreach (string s in File.ReadAllLines(info_directory)) {
                tokens_dictionary.Add(s.Substring(0, s.IndexOf(':')), s[(s.IndexOf(':') + 1)..]);
            }
        }

        public async Task<string> SendRequest(string command, string receiver="", ulong _quantity=0, string body_text="") {
            string quantity = _quantity.ToString();
            string request_type = tokens_dictionary[command.ToUpper()];
            string uri = tokens_dictionary[command]
                .Replace("{name}", current_user.username)
                .Replace("{name2}", receiver)
                .Replace("{quantity}", quantity);
            HttpRequestMessage request_message = new HttpRequestMessage(new HttpMethod(request_type), uri) {
                Content = new StringContent(body_text, Encoding.UTF8, "application/json"),
            };
            request_message.Headers.Add("Password", current_user.password);
            HttpResponseMessage response_message = await http_client.SendAsync(request_message);
            CheckForSuccess(response_message, _quantity);
            return await response_message.Content.ReadAsStringAsync();
        }

        private bool CheckForSuccess(HttpResponseMessage response_message, ulong quantity) {
            if (!response_message.IsSuccessStatusCode) {
                switch ((int)response_message.StatusCode) {
                    case -1: throw new UserNotFoundException(current_user.username);
                    case -2: throw new InvalidPasswordException(current_user.password);
                    case -3: throw new InvalidRequestException();
                    case -4: throw new NameTooLongException(current_user.username);
                    case -5: throw new UserAlreadyExistsException(current_user.username);
                    case -6: throw new InsufficientFundsException(current_user.username, quantity);
                }
            }
            return true;
        }
    }*/
    public abstract class Communication {
        private HttpClient _http = new();
    }
}