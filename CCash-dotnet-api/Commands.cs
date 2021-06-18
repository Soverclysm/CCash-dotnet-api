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
            return await comms.GET("GetBal", username);
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

        public async Task ChangePassword(string username, string password, string new_password) {
            await comms.PATCH(username, password, "ChangePassword", new_password);
        }

        public async Task ChangePassword(string new_password) {
            if (!await @is()) throw new AuthenicationFailureException();
            await comms.PATCH("ChangePassword", new_password);
        }

        #endregion

        #region SetBal

        public async Task SetBal(string username, string password, string new_balance) {
            await comms.PATCH(username, password, "SetBal", new_balance);
        }

        public async Task SetBal(string new_balance) {
            if (!await @is()) throw new AuthenicationFailureException();
            else await comms.PATCH("SetBal", new_balance);
        }

        #endregion SetBal

        #region Help

        public async Task<string> Help() {
            return await comms.GET("Help");
        }

        #endregion

        #region Ping

        public async Task<string> Ping() {
            return await comms.GET("Ping");
        }

        #endregion

        #region Close

        public async Task Close(string password) {
            await comms.POST("Close", password,"",""); // cry about it
        }

        public async Task Close() {
            await comms.POST("Close");
        }

        #endregion

        #region Contains

        public async Task<string> Contains(string username) {
            return await comms.GET("Contains", username);
        }

        public async Task<string> Contains() {
            return await comms.GET("Contains");
        }

        #endregion Contains

        #region AdminVerifyPass

        public async Task<string> AdminVerifyPass(string password) {
            return await comms.GET("", password, "AdminVerifyPass");
        }

        public async Task<string> AdminVerifyPass() {
            return await comms.GET("AdminVerifyPass"); 
        }

        #endregion

        #region AddUser

        public async Task AddUser(string username, string password) {
            await comms.POST("AddUser", password, username);
        }

        public async Task AddUser() {
            await comms.POST("AddUser");
        }

        #endregion

        #region AdminAddUser

        public async Task AdminAddUser(string username, string password, string init_bal, string new_password) {
            await comms.BODY_POST("AdminAddUser", password, new_password, quantity: init_bal);
        }

        public async Task AdminAddUser(string init_bal, string new_password) {
            await comms.BODY_POST("AdminAddUser", new_password, quantity: init_bal);
        }

        #endregion

        #region DelUser

        public async Task DelUser(string username, string password) {
            await comms.DELETE(username, password, "DelUser");
        }

        public async Task DelUser() {
            await comms.DELETE("DelUser");
        }

        #endregion

        #region AdminDelUser

        public async Task AdminDelUser(string username, string password) {
            await comms.DELETE(username, password, "AdminDelUser");
        }

        public async Task AdminDelUser() {
            await comms.DELETE("AdminDelUser");
        }

        #endregion
    }
}