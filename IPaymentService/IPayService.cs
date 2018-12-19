using IPaymentService.Model;
using PaymentServiceLib.Model.Request;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace IPaymentService
{
    [ServiceContract]
    public interface IPayService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Xml, 
            BodyStyle = WebMessageBodyStyle.Wrapped, 
            UriTemplate = "xml/{id}")]
        string XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Wrapped, 
            UriTemplate = "json/{id}")]
        string JSONData(string id);

        [OperationContract]
        bool Connect(SocketConnectRequest connectRequest);


        [OperationContract(Name = "HeartBeat")]
        bool CheckHeartBeat();

       // [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "PaymentRequest")]

        /// <summary>Sends a request to the EFT-Client</summary>
        /// <param name="request">The <see cref="TerminalBaseRequest"/> to send</param>
        /// <param name="member">Used for internal logging. Ignore</param>
        /// <returns>FALSE if an error occurs</returns>
        bool PaymentRequest(PaymentRequest request, string member = "");
    }
}