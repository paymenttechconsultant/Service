using DependenyInjector;
using PaymentServiceLib.Entry;
using PaymentServiceLib.Enum;
using PaymentServiceLib.Model;
using PaymentServiceLib.Model.Request;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestPaymentService
{
    enum NotificationType { Normal, Error, Success };

    public partial class Form1 : Form
    {
        bool _isServerVerified = false;
        ITerminalUtil connUtil = DependencyInjector.Get<ITerminalUtil, TerminalUtil>();
        public Form1()
        {
            
            InitializeComponent();
            btnConnect.BackColor = Color.Red;
            connUtil.OnTerminated += _eft_OnTerminated;
 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        void _eft_OnTerminated(object sender, SocketEventArgs e)
        {
            // OnTerminated can be called from a different thread. Always ensure we are in the UI thread.
            if (!this.InvokeRequired)
            {
                // Dispatcher.Invoke(() => _eft_OnTerminated(sender, e));
                return;
            }

            _isServerVerified = false;

        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string host = "127.0.0.1:2011";
            if (Connect(host))
            {

                var addr = host.Split(new char[] { ':' });
                btnConnect.BackColor = Color.Green;
                btnConnect.Enabled = false;

                btnTender.Enabled = true;
                MessageBox.Show(string.Format("Connection established ar Host={0} and port={1}", addr[0], addr[1]), "Success");
            }
            else
            {
                btnConnect.BackColor = Color.Green;

                btnTender.Enabled = true;
            }
        }
        bool Connect(string HostAddress)
        {

           

            bool _isServerVerified = false;
            bool _navigating = false;

            var tmpPort = 0;
            var addr = HostAddress.Split(new char[] { ':' });
            if (addr.Length < 2 || int.TryParse(addr[1], out tmpPort) == false)
            {
                //logger.Log(NLog.LogLevel.Error, "INVALID ADDRESS");
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
                // logger.Log(NLog.LogLevel.Error, "ERROR CONTACTING TO POSCLIENT");
                _isServerVerified = false;
            }
            return _isServerVerified;
        }

        private void btnTender_Click(object sender, EventArgs e)
        {
            var r = new ECRTransactionRequest();
            // TxnType is required
            r.TxnType = TransactionType.Purchase;
            // Set ReferenceNumber to something unique
            r.CustomerReference = DateTime.Now.ToString("YYMMddHHmmssfff");
            // Set AmountCash for cash out, and AmountPurchase for purchase/refund
            r.AmtPurchase = (r.TxnType == TransactionType.CashOut) ? 0 : decimal.Parse(txtAmount.Text);
           
            // Set POS or pinpad printer
            
            // Set application. Used for gift card & 3rd party payment
            

            if (!connUtil.DoTransaction(r))
            {
                ShowNotification("FAILED TO SEND TXN", "", "", NotificationType.Error, true);
            }
        }
        void ShowNotification(string line1, string line2, string line3, NotificationType notificationType, bool enableOkButton)
        {
            MessageBox.Show(line1, notificationType.ToString(), MessageBoxButtons.OK);
        }

    }
}
