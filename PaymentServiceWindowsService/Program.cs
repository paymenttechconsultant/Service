using System.ServiceProcess;

namespace PaymentServiceWindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static void Main()
        {
#if DEBUG
            PaymentServiceHost myservice = new PaymentServiceHost();
            myservice.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            #else
            ServiceBase[] ServicesToRun;

            ServicesToRun = new ServiceBase[]
            {
                new PaymentServiceHost()
            };

            ServiceBase.Run(ServicesToRun);
            #endif
        }

    }
}