using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCash_dotnet_api {
    public class CCashClient: Communication {
        public CCashClient(string webServer, string username, string password): base(webServer, username, password) {}
        public async Task<GetBalResponse>          GetBal()                                   => await SendRequest<GetBalResponse>("GetBal");
        public async Task<GetLogsResponse>         GetLogs()                                  => await SendRequest<GetLogsResponse>("GetLog");
        public async Task<IResponse>               SendFunds(string receiver, uint funds)     => await SendRequest<IResponse>("SendFunds", receiver, funds.ToString());
        public async Task<VerifyPasswordResponse>  VerifyPassword()                           => await SendRequest<VerifyPasswordResponse>("VerifyPassword");
        public async Task<IResponse>               ChangePassword(string newPassword)         => await SendRequest<IResponse>("SendRequest", bodyText: newPassword);
        public async Task<IResponse>               SetBal(uint newBal)                        => await SendRequest<IResponse>("SetBal", quantity: newBal.ToString());
        public async Task<HelpResonse>             Help()                                     => await SendRequest<HelpResonse>("Help");
        public async Task<PingResponse>            Ping()                                     => await SendRequest<PingResponse>("Ping");
        public async Task<IResponse>               Close()                                    => await SendRequest<IResponse>("Close");
        public async Task<ContainsResponse>        Contains()                                 => await SendRequest<ContainsResponse>("Contains");
        public async Task<AdminVerifyPassResponse> AdminVerifyPass()                          => await SendRequest<AdminVerifyPassResponse>("AdminVerifyPass");
        public async Task<IResponse>               AddUser()                                  => await SendRequest<IResponse>("AddUser");
        public async Task<IResponse>               AdminAddUser(string newPass, uint initBal) => await SendRequest<IResponse>("AdminAddUser", bodyText: newPass, quantity: initBal.ToString());
        public async Task<IResponse>               DelUser()                                  => await SendRequest<IResponse>("DelUser");
        public async Task<IResponse>               AdminDelUser()                             => await SendRequest<IResponse>("AdminDelUser");
    }
}
