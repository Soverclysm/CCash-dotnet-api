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

        private readonly HttpClient http_client = new HttpClient();
        public User current_user = new User("", "");
        public Dictionary<string, string> command_tokens;

        public Communication() {
            command_tokens = populate_command_tokens();
        }

        // shortens the url links, i cba
        public Dictionary<string, string> populate_command_tokens() {
            Dictionary<string, string> arg = new Dictionary<string, string>();
            string[] tokens = {"GetBal", "GetLog", "SendFunds", "VerifyPassword", "ChangePassword", "SetBal", "Help",
            "Close", "Contains", "AdminVerifyPass", "AddUser", "AdminAddUser", "DelUser", "AdminDelUser"};
            string[] urls = {"{name}/bal", "{name}/log", "{name}/send/{name2}?amount={quantity}", "{name}/pass/verify",
            "{name}/pass/change", "admin/{name}/bal?amount={quantity}", "help", "admin/close", "contains/{name}",
            "admin/verify", "user/{name}", "admin/user/{name}?init_bal={quantity}", "user/{name}", "admin/user/{name}"};
            for (int i = 0; i < tokens.Length; i++) {
                arg.Add(tokens[i], $"https://wtfisthis.tech/BankF/{urls[i]}");
            }
            return arg;
        }

        /*public async Task<string> SendRequest(string command, string request_type, string password="", string username="", string username2="", string quantity="", string body_text="") {
            string uri = command_tokens[command]
                .Replace("{name}", username)
                .Replace("{name2}", username2)
                .Replace("{quantity}", quantity);
            HttpRequestMessage request_message = new HttpRequestMessage(new HttpMethod(request_type), uri) {
                Content = new StringContent(body_text, Encoding.UTF8, "application/json"),
            };
            request_message.Headers.Add("Password", password);
            HttpResponseMessage response_message = await http_client.SendAsync(request_message);
            return await response_message.Content.ReadAsStringAsync();
        }*/

        public async Task<string> SendRequest(string command, string request_type, string username2="", string quantity="", string body_text="") {
            string uri = command_tokens[command]
                .Replace("{name}", current_user.username)
                .Replace("{name2}", username2)
                .Replace("{quantity}", quantity);
            HttpRequestMessage request_message = new HttpRequestMessage(new HttpMethod(request_type), uri) {
                Content = new StringContent(body_text, Encoding.UTF8, "application/json"),
            };
            request_message.Headers.Add("Password", current_user.password);
            HttpResponseMessage response_message = await http_client.SendAsync(request_message);
            return await response_message.Content.ReadAsStringAsync();
        }


    }
}