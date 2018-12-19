using IPaymentService.Services.ServiceCallBack;
using System;

namespace PaymentServiceWindowsService.ServiceFactory
{
    public class CallBackHandler :  IConncetionCallback
    {
        public void OnDeviceDisconnect(DateTime dt, bool response)
        {

            Console.WriteLine($"Servive Callback on :- {dt.ToLongDateString()} and server conncetion status:- {response}.");
        }
    }
}
