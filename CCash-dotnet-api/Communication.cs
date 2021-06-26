using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace CCash_dotnet_api {
    public class Communication: Tokens {

        private HttpClient _http = new();
        private User _user;
        private string _auth;

        public string ConnectedWebserver { get; set; }

        public Communication(string webServer, string username, string password): base() {
            ConnectedWebserver = webServer;
            _user = new User(username, password);
            _auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            _http.DefaultRequestHeaders.Add("Content-Type", "application/json");
            _http.DefaultRequestHeaders.Add("Accept", "application/json");
            _http.DefaultRequestHeaders.Add("Authorization", _auth);
        }

        public async Task<T> SendRequest<T>(string command, string username2="", string quantity="") where T: IResponse {
            string uri = GetUri(ConnectedWebserver, command);
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod(TokensDictionary[command.ToUpper()]), uri);
            HttpResponseMessage responseMessage = await _http.SendAsync(requestMessage);
            CheckForSuccess(responseMessage, quantity);
            var json = responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json.Result);
        }

        public async Task<T> SendRequest<T>(string command, string bodyText, string username2 = "", string quantity = "") where T: IResponse {
            string uri = GetUri(ConnectedWebserver, command);
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod(TokensDictionary[command.ToUpper()]), uri) {
                Content = new StringContent(bodyText, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = await _http.SendAsync(requestMessage);
            CheckForSuccess(responseMessage, quantity);
            var json = responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json.Result);
        }

        private string GetUri(string webServer, string commandName, string username = "", string username2 = "", string quantity = "") {
            string extendedLink = TokensDictionary[commandName]
                .Replace("{name}", username)
                .Replace("{name2}", username2)
                .Replace("quantity", quantity);
            return $"{webServer}{extendedLink}";
        }

        private void CheckForSuccess(HttpResponseMessage response_message, string quantity) {
            if (!response_message.IsSuccessStatusCode) {
                switch ((int)response_message.StatusCode) {
                    case -1: throw new UserNotFoundException(_user.username);
                    case -2: throw new InvalidPasswordException(_user.password);
                    case -3: throw new InvalidRequestException();
                    case -4: throw new NameTooLongException(_user.username);
                    case -5: throw new UserAlreadyExistsException(_user.username);
                    case -6: throw new InsufficientFundsException(_user.username, quantity);
                }
            }
        }
    }
}