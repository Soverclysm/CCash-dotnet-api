using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCash_dotnet_api {
    class Commands {

        public Communication comms = new Communication();

        public async Task CreateAccount(string username, string password) {
            comms.authentication_details = new Auth(username, password);
            await comms.flush_details();
        }

        private async Task<bool> @is() {
            return! (comms.authentication_details.username == "");
        }

        #region GetBal 

        public async Task<string> GetBal(string username) {
            return await comms.@GET("GetBal", username);
        }

        public async Task<string> GetBal() {
            if (!await @is()) return "ERROR: You have not specified CCash.Auth details";
            else return await comms.@GET("GetBal");
        }

        #endregion

        #region GetLog

        public async Task<string> GetLog(string username) {
            return await comms.GET("GetLog", username);
        }

        public async Task<string> GetLog() {
            if (!await @is()) return "ERROR: You have not specified CCash.Auth details";
            else return await comms.GET("GetLog");
        }

        #endregion

        #region SendFunds

        public async Task SendFunds(string username, string username2, string quantity, string password) {
            await comms.POST("SendFunds", password, username, username2, quantity);
        }

        public async Task SendFunds(string username2, string quantity) {
            if (!await @is()) throw new AuthenicationFailureException();
            else await comms.POST("SendFunds", username2, quantity);
        }

        #endregion

        #region VerifyPassword

        public async Task<string> VerifyPassword(string username, string password) {
            return await comms.GET(username, password, "VerifyPassword");
        }

        public async Task<string> VerifyPassword() {
            if (!await @is()) return "ERROR: You have not specified CCash.Auth details";
            else return await comms.GET("VerifyPassword");
        }

        #endregion

        #region ChangePassword

        public async Task ChangePassword(string username, string password) {
            await comms.PATCH(username, password, "ChangePassword");
        }

        public async Task ChangePassword() {
            if (!await @is()) throw new AuthenicationFailureException();
            await comms.PATCH("ChangePassword");
        }

        #endregion

        #region SetBal

        public async Task SetBal(string username, string password, string quantity) {
            await comms.PATCH(username, password, "SetBal");
        }

        public async Task SetBal(string quantity) {
            if (!await @is()) throw new AuthenicationFailureException();
            else await comms.PATCH("SetBal", quantity);
        }


        #endregion SetBal

    }
}