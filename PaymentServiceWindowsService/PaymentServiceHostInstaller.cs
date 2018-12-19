namespace PaymentServiceWindowsService
{
    #region Namespaces
    using System.ComponentModel;
    using System.ServiceProcess;
    #endregion

    [RunInstaller(true)]
    public partial class PaymentServiceHostInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public PaymentServiceHostInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "IPaymentTerminal";
            service.Description = "WCF REST API Hosting on Windows Service";
            service.DelayedAutoStart = true;
            Installers.Add(process);
            Installers.Add(service);
        }

    }
}








