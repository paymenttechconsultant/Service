using NLog;
using System;
using DependenyInjector;
using PaymentServiceLib.Entry;
using Responses;
using IPaymentService.Model;
using PaymentServiceLib.Model.Request;
using PaymentServiceLib.Enum;

namespace IPaymentService.ServiceUtil
{
    public class Connection : IConnection
    {
        private static Logger logger = LogManager.GetLogger("PaymentServiceLog");
        private ITerminalUtil connUtil= DependencyInjector.Get<ITerminalUtil, TerminalUtil>();
        bool _isServerVerified = false;
        bool _checkHeartBeat = false;

        public Connection()
        {
            connUtil.OnTerminated += OnDeviceOffline;
            connUtil.OnSocketFail += OnSocketError;
        }

        public bool CheckConnectionStatus(ResponseBase response)
        {
            _checkHeartBeat= connUtil.IsConnected;
            if (!_checkHeartBeat)
            {
                response.FaultItemList.Add(Faults.TerminalDisconnect);
            }
            return _checkHeartBeat;
        }

        public bool Connect(string HostAddress, ResponseBase response)
        {
            try
            {
                var tmpPort = 0;
                var addr = HostAddress.Split(new char[] { ':' });
                if (addr.Length < 2 || int.TryParse(addr[1], out tmpPort) == false)
                {
                    logger.Log(NLog.LogLevel.Error, "INVALID ADDRESS");
                    response.FaultItemList.Add(Faults.INVALIDADDRESS);
                    return false;
                }
                connUtil.HostName = addr[0];
                connUtil.HostPort = tmpPort;

                var connected = connUtil.Connect();
                if (connected)
                {
                    _isServerVerified = true;
                }
                else
                {
                    response.FaultItemList.Add(Faults.UnknownError);
                    logger.Log(NLog.LogLevel.Error, "ERROR CONTACTING TO POSCLIENT");
                    _isServerVerified = false;
                }
            }
            catch (Exception e)
            {
                response.FaultItemList.Add(Faults.UnknownError);
                logger.Error(String.Format($"Terminal Socket Error=ErrorMessage={0},ErroType={1}",
                e.Message, e.StackTrace));
                throw e;
            }
            response.FaultItemList.Add(Faults.INVALIDADDRESS);
            return _isServerVerified;
        }

        public bool PayRequest(PaymentRequest request, string member = "")
        {
            bool response = false;
            ECRTransactionRequest eCRTransactionRequest = new ECRTransactionRequest();
            //if (eCRTransactionRequest == null)
            {
                if (request.transactionType == 0)
                {
                    eCRTransactionRequest.TxnType = TransactionType.Purchase;
                }
                eCRTransactionRequest.AmtPurchase = request.amtPurchase;
                eCRTransactionRequest.tenderType = request.tenderType;
                eCRTransactionRequest.Merchant = request.merchant;
                eCRTransactionRequest.Invoice = request.invoice;
                eCRTransactionRequest.CustomerReference = request.customerReference;
                eCRTransactionRequest.AuthCode = request.authCode;
                eCRTransactionRequest.Reference = request.reference;
                eCRTransactionRequest.Pan = request.pan;
                eCRTransactionRequest.ReceiptAutoPrint = request.receiptAutoPrint;

                response = connUtil.DoRequest(eCRTransactionRequest, "");
            }
            return response;
        }

        private void OnDeviceOffline(object sender, SocketEventArgs e)
        {

            logger.Error(String.Format($"Terminal Socket Error=ErrorMessage={0},ErroType={1}",
                e.ErrorMessage,e.ErrorType));
            _checkHeartBeat = false;
        }
        private void OnSocketError(object sender, SocketEventArgs e)
        {

            logger.Error(String.Format($"Terminal Disconnect=ErrorMessage={0},ErroType={1}",
                e.ErrorMessage, e.ErrorType));
            _checkHeartBeat = false;
        }
    }


}
