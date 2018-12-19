using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IPaymentService.Model
{
   public class SocketConnectRequest
    {
        [DataMember]
        public string Host { get; set; }
        [DataMember]
        public int Port { get; set; }
    }
}
