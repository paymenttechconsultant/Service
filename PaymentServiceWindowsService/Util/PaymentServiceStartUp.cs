using IPaymentService.Model;
using NLog;
using PaymentServiceWindowsService.ServiceFactory;
using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading;

namespace PaymentServiceWindowsService.Util
{
    public class PaymentServiceStartUp : IDisposable
    {
        private Logger logger = null;
        private bool IsServerConnected = false;
        private Mutex mMutex;
       // private int mBatchId = 0;
        private bool mIsWaiting = false;
        private bool disposed = false;
       // private bool mDebug = false;
        private string Host { get; } = ConfigurationManager.AppSettings["Host"];
        private string Endpoint { get; } = ConfigurationManager.AppSettings["TCPServiceEndPoint"];

        private int Port { get; }= Convert.ToInt32( ConfigurationManager.AppSettings["Port"]);

        private GenericProxy<IPaymentService.IPayService> payServiceConnect = null;


        public PaymentServiceStartUp(Logger logger)
        {            
            this.logger = logger;
            mMutex = new Mutex();
            payServiceConnect = new GenericProxy<IPaymentService.IPayService>(new NetTcpBinding(),new EndpointAddress(Endpoint));
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Process(Object stateInfo)
        {
            try
            {
                if (mMutex.WaitOne(0, false) == false)
                    return;
                Debug.WriteLine("service is running " + DateTime.Now.ToString());
                CheckDeviceHeartBeat();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ConnectionWindowsService Error", new object[] { ex.Data, ex.Message, ex.StackTrace });
            }
            mMutex.ReleaseMutex();            
        }

        private void CheckDeviceHeartBeat()
        { 
            try
            {
                if (!IsServerConnected)
                {
                    payServiceConnect.Execute(C =>
                    {
                        SocketConnectRequest socketConnect = new SocketConnectRequest()
                        {
                            Port = this.Port,
                            Host = this.Host
                        };


                        IsServerConnected = C.Connect(socketConnect);

                        Debug.WriteLine("ConnectionWindowsService:- ServerConnected " + IsServerConnected);
                        logger.Info("ConnectionWindowsService:- ServerConnected");
                    });
                }
                else
                {
                    Action<IPaymentService.IPayService> action = (x =>
                    {
                        IsServerConnected = x.CheckHeartBeat();
                        Debug.WriteLine("ConnectionWindowsService:- ServerConnected " + IsServerConnected);
                        logger.Info("ConnectionWindowsService:- ServerConnected " + IsServerConnected);
                    });
                    payServiceConnect.Execute(action);

                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                throw Ex;
            }
        }


        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {

                }

                mMutex.Close();
                mMutex = null;

                logger.Error("ConnectionWindowsService Error");
            }
        }
        public void Wait(int millisecondTimeout)
        {
            mIsWaiting = true;
            mMutex.WaitOne(millisecondTimeout, false);
            mIsWaiting = false;
        }
    }
}
