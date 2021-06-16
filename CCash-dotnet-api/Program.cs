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

        static void Main() { }

        #region GET commands, requires {name}

        public async Task<string> get_async_req_username(string username, string command) {
            string server_url = command_tokens[command].Replace("{name}", username);
            HttpWebRequest web_request = (HttpWebRequest)WebRequest.Create(server_url);
            HttpWebResponse server_response = (HttpWebResponse)await web_request.GetResponseAsync();
            Stream response_stream = server_response.GetResponseStream();
            StreamReader stream_reader = new StreamReader(response_stream);
            return await stream_reader.ReadToEndAsync();
        }

        public async Task<string> GetBal(string username) =>
            await get_async_req_username(username, "GetBal");

        public async Task<string> Help() =>
            await get_async_req_username("", "Help");

        public async Task<string> Contains(string username) =>
            await get_async_req_username(username, "Contains");

        #endregion

        #region GET commands, requires {name}, authentication

        public async Task<string> get_async_req_username_password(string username, string password, string command) {
            string server_url = command_tokens[command].Replace("{name}", username);
            HttpWebRequest web_request = (HttpWebRequest)WebRequest.Create(server_url);
            web_request.Headers["Password"] = password;
            HttpWebResponse server_response = (HttpWebResponse)await web_request.GetResponseAsync();
            Stream response_stream = server_response.GetResponseStream();
            StreamReader stream_reader = new StreamReader(response_stream);
            return await stream_reader.ReadToEndAsync();
        }

        public async Task<string> GetLog(string username, string password) =>
            await get_async_req_username_password(username, password, "GetLog");

        public async Task<string> VerifyPassword(string username, string password) =>
            await get_async_req_username_password(username, password, "VerifyPassword");

        public async Task<string> AdminVerifyPass(string password) =>
            await get_async_req_username_password("", password, "AdminVerifyPass");

        #endregion

        #region POST commands

        public async Task<string> post_async(string username, string password, string username2, string quantity, string command) {
            string server_url = command_tokens[command].Replace("{name}", username).Replace("{name2}", username2).Replace("{quantity}", quantity);

            HttpWebRequest web_request = (HttpWebRequest)WebRequest.Create(server_url);
            var post_data = "thing1="

        }

        #endregion

    }
}