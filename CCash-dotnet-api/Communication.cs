using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net;

namespace CCash_dotnet_api {
    class Communication {

        private readonly HttpClient http_client = new();
        public User current_user = new();
        public Dictionary<string, string> command_tokens, request_tokens;

        public Communication() {
            command_tokens = populate_command_tokens();
            request_tokens = populate_request_tokens();
        }

        // shortens the url links, i cba
        public Dictionary<string, string> populate_command_tokens() {
            Dictionary<string, string> arg = new();
            string[] tokens = {"GetBal", "GetLog", "SendFunds", "VerifyPassword", "ChangePassword", "SetBal", "Help", "Ping",
            "Close", "Contains", "AdminVerifyPass", "AddUser", "AdminAddUser", "DelUser", "AdminDelUser"};
            string[] urls = {"{name}/bal", "{name}/log", "{name}/send/{name2}?amount={quantity}", "{name}/pass/verify",
            "{name}/pass/change", "admin/{name}/bal?amount={quantity}", "help", "ping", "admin/close", "contains/{name}",
            "admin/verify", "user/{name}", "admin/user/{name}?init_bal={quantity}", "user/{name}", "admin/user/{name}"};
            for (int i = 0; i < tokens.Length; i++) {
                arg.Add(tokens[i], $"https://wtfisthis.tech/BankF/{urls[i]}");
            }
            return arg;
        }
        public Dictionary<string, string> populate_request_tokens() {
            Dictionary<string, string> arg = new();
            string[] commands = {"GetBal", "GetLog", "SendFunds", "VerifyPassword", "ChangePassword", "SetBal", "Help", "Ping",
            "Close", "Contains", "AdminVerifyPass", "AddUser", "AdminAddUser", "DelUser", "AdminDelUser"};
            string[] requests = {"GET", "GET", "POST", "GET", "PATCH", "PATCH", "GET", "GET", "POST", "GET", "GET", "POST", "POST",
            "DELETE", "DELETE"};
            for (int i = 0; i < commands.Length; i++) {
                arg.Add(commands[i], requests[i]);
            }
            return arg;
        }

        public async Task<string> SendRequest(string command, string receiver="", ulong _quantity=0, string body_text="") {
            string quantity = _quantity.ToString();
            string request_type = request_tokens[command];
            string uri = command_tokens[command]
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
                    case -2: throw new InvalidPasswordException(current_user.password, current_user.username);
                    case -3: throw new InvalidRequestException();
                    case -4: throw new NameTooLongException(current_user.username);
                    case -5: throw new UserAlreadyExistsException(current_user.username);
                    case -6: throw new InsufficientFundsException(current_user.username, quantity);
                }
            }
            return true;
        }
    }
}