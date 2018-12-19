using System.ServiceProcess;
using System.ServiceModel;
using System.Threading;
using PaymentServiceWindowsService.Util;
using NLog;
using System;
using System.Diagnostics;

namespace PaymentServiceWindowsService
{
    public partial class PaymentServiceHost : ServiceBase
    {
        private Timer mTimer;
        private ServiceHost oServiceHost = null;
        private PaymentServiceStartUp PaymentServiceStartUp = null;
        private static Logger logger = LogManager.GetLogger("PaymentWindowsServiceLog");

        public PaymentServiceHost()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            if (oServiceHost != null)
            {
                oServiceHost.Close();
            }

            oServiceHost = new ServiceHost(typeof(IPaymentService.PayService));
            oServiceHost.Open();

            Debug.WriteLine("PaymentService  started " + DateTime.Now.ToString());

            PaymentServiceStartUp = new PaymentServiceStartUp(logger);
            TimerCallback timerDelegate = new TimerCallback(PaymentServiceStartUp.Process);
            mTimer = new System.Threading.Timer(timerDelegate, mTimer, 0,
            Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["frequency"]));



        }
        // When system shuts down
        protected override void OnShutdown()
        {
            // Add your save code here
            base.OnShutdown();
        }
        protected override void OnStop()
        {
            if (oServiceHost != null)
            {
                oServiceHost.Close();
                oServiceHost = null;
            }
            if (mTimer != null)
            {
                mTimer.Dispose();
                mTimer = null;
            }

        }

        private void ServiceStartUP()
        {
            //Setup Service           
            this.CanStop = true;
            this.CanPauseAndContinue = true;

            //Setup logging
            this.AutoLog = false;

            //((ISupportInitialize)this.EventLog).BeginInit();
            //if (!EventLog.SourceExists(this.ServiceName))
            //{
            //    EventLog.CreateEventSource(this.ServiceName, "PaymentHostService");
            //}
            //((ISupportInitialize)this.EventLog).EndInit();

            this.EventLog.Source = this.ServiceName;
            this.EventLog.Log = "PaymentWindowstService";
            logger.Info("PaymentWindowstService");
        }
    }
}