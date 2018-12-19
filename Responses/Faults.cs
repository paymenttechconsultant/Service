using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{

    public class Faults
    {
        public static Fault UnknownError { get; } = new Fault("Unknown", "UnknownError", "Cause and origin of this error is unknown");
        public static Fault INVALIDADDRESS { get; } = new Fault("SocketConnection", "INVALIDADDRESS", "Unknown Host and Port.");
        public static Fault TerminalDisconnect { get; } = new Fault("TerminalDisconnect", "DeviceOffline", "Terminal is ofline");


    }
}
