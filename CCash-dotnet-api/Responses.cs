using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCash_dotnet_api {
    public struct Log { 
        public uint Amount { get; set; }
        public string From { get; set; }
        public ulong Time { get; set; }
        public string To { get; set; }
    }
    public interface IResponse {}
    public class GetBalResponse: IResponse {
        public uint Balance { get; set; }
    }
    public class GetLogsResponse: IResponse {
        public List<Log> Logs { get; set; }
    }
    public class VerifyPasswordResponse: IResponse {
        public string Verified { get; set; }
    }
    public class HelpResonse: IResponse {
        public string Content { get; set; }
    }
    public class PingResponse: IResponse {
        public string Content { get; set; }
    }
    public class ContainsResponse: IResponse {
        public string Contains { get; set; }
    }
    public class AdminVerifyPassResponse: IResponse {
        public string Verified { get; set; }
    }
}
