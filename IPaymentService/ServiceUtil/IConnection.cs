using IPaymentService.Model;
using Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPaymentService.ServiceUtil
{
   public interface IConnection
    {
        bool Connect(string HostAddress,ResponseBase response);
        bool CheckConnectionStatus(ResponseBase response);

        bool PayRequest(PaymentRequest request, string member = "");
    }
}
