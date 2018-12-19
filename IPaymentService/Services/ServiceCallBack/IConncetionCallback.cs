using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPaymentService.Services.ServiceCallBack
{
   public interface IConncetionCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnDeviceDisconnect(DateTime dt, bool response);
    }
}
