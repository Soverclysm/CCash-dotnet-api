using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace CCash_dotnet_api {
    class Communication {

        private static readonly HttpClient http_client = new HttpClient();

        public static Dictionary<string, string> command_tokens = populate_command_tokens();

        // shortens the url links, i cba
        public static Dictionary<string, string> populate_command_tokens() {
            Dictionary<string, string> arg = new Dictionary<string, string>();
            string[] tokens = {"GetBal", "GetLog", "SendFunds", "VerifyPassword", "ChangePassword", "SetBal", "Help",
            "Close", "Contains", "AdminVerifyPass", "AddUser", "AdminAddUser", "DelUser", "AdminDelUser"};
            string[] urls = {"{name}/bal", "{name}/log", "{name}/send/{name2}/amount={quantity}", "{name}/pass/verify",
            "{name}/pass/change", "admin/{name}/bal/amount={quantity}", "help", "admin/close", "contains/{name}",
            "admin/verify", "user/{name}", "admin/user/{name}?init_bal={quantity}", "user/{name}", "admin/user/{name}"};
            for (int i = 0; i < tokens.Length; i++) {
                arg.Add(tokens[i], $"https://wtfisthis.tech/BankF/{urls[i]}");
            }
            return arg;
        }

        private async Task input_password(string password) {
            if (!http_client.DefaultRequestHeaders.Contains("Password")) http_client.DefaultRequestHeaders.Add("Password", password);
            else {
                http_client.DefaultRequestHeaders.Remove("Password");
                http_client.DefaultRequestHeaders.Add("Password", password);
            }
        }

        #region GET

        public async Task<string> get_async(string command, string username = "") {
            return await http_client.GetStringAsync(command_tokens[command].Replace("{name}", username));
        }

        public async Task<string> get_async(string username, string password, string command) {
            await input_password(password);
            return await http_client.GetStringAsync(command_tokens[command].Replace("{name}", username));
        }

        #endregion

        #region POST

        public async Task post_async(string command, string password, string username = "", string username2 = "", string quantity = "") {
            await input_password(password);
            await http_client.PostAsync(command_tokens[command]
                .Replace("{name}", username)
                .Replace("{name2}", username2)
                .Replace("{quantity}", quantity)
                , null);
        }

        #endregion

        #region PATCH

        public async Task patch_async(string username, string password, string command, string quantity = "") {
            await input_password(password);
            await http_client.PatchAsync()
        }

        #endregion
    }
}