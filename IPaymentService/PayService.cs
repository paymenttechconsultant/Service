using DependenyInjector;
using IPaymentService.Model;
using IPaymentService.ServiceUtil;
using Responses;

namespace IPaymentService
{
    public class PayService : IPayService
    {
        private bool result = false;
        IConnection connection = DependencyInjector.Get<IConnection, Connection>();

        public bool CheckHeartBeat()
        {
            ResponseBase response = new ResponseBase();
            result = connection.CheckConnectionStatus(response);
            return result;
        }

        public bool Connect(SocketConnectRequest connectRequest)
        {
            ResponseBase response = new ResponseBase();
            var hostaddress = $"{connectRequest.Host}:{connectRequest.Port}";
            result = connection.Connect(hostaddress, response);
            return result;
        }
        public string XMLData(string id)
        {
            return Data(id);
        }
        public string JSONData(string id)
        {
            return Data(id);
        }

        private string Data(string id)
        {
            // logic
            return "Data: " + id;
        }

        public bool PaymentRequest(PaymentRequest request, string member = "")
        {
            return connection.PayRequest(request, member);
        }
    }
}