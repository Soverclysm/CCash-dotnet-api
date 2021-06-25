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
    public interface Response {}
    public class GetBalResponse: Response {
        public ulong Balance { get; set; }
    }
    public class GetLogsResponse: Response {
        public List<Log> Logs { get; set; }
    }
    public class VerifyPasswordResponse: Response {
        public bool Verified { get; set; }
    }
    public class HelpResonse: Response {
        public string Content { get; set; }
    }
    public class PingResponse: Response {
        public string Content { get; set; }
    }
    public class ContainsResponse: Response {
        public bool Contains { get; set; }
    }
    public class AdminVerifyPassResponse: Response {
        public bool Verified { get; set; }
    }
}
