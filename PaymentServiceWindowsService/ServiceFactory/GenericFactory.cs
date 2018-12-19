using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Configuration;

namespace PaymentServiceWindowsService.ServiceFactory
{
    public enum ChannelType
    {
        Single,
        Duplex
    }
   internal sealed class GenericProxy<TContract> : IDisposable where TContract : class
    {
        
        private ChannelFactory<TContract> _channelFactory;
        private TContract _channel;
        private bool _disposed = false;
        private readonly Object _sync = new object();
        private string BindinngConfig=ConfigurationManager.AppSettings["BindingConfig"];
      

        private TContract Channel
        {
            get
            {
                lock (_sync)
                {
                    if (_channel == null)
                    {
                        _channel = _channelFactory.CreateChannel();
                    }
                    
                return _channel;
                }
            }
        }
        public GenericProxy()
        {
            _channelFactory = new ChannelFactory<TContract>(String.Empty);
        }
        public GenericProxy(Binding binding, EndpointAddress remoteAddress)
        {
            _channelFactory = new ChannelFactory<TContract>(binding, remoteAddress);
        }
        public TResult Execute<TResult>(Func<TContract, TResult> function)
        {
            return function.Invoke(Channel);
        }

        public void Execute(Action<TContract> action)
        {
            action.Invoke(Channel);
        }
        ~GenericProxy() {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            //try
            //{
            //    if (_channel != null)
            //    {
            //        var currentChannel = _channel as IClientChannel;
            //        if (currentChannel.State == CommunicationState.Faulted)
            //        {
            //            currentChannel.Abort();
            //        }
            //        else
            //        {
            //            currentChannel.Close();
            //        }
            //    }
            //}
            //finally
            //{
            //    _channel = null;
            //    GC.SuppressFinalize(this);
            //}
        }

        private void Dispose(bool v)
        {
            if (_disposed)
                return;
            if (v) {
                lock (_sync) {
                    if (_channel != null)
                    {
                        var currentChannel = _channel as IClientChannel;
                        if (currentChannel.State == CommunicationState.Faulted)
                        {
                            currentChannel.Abort();
                        }
                        else
                        {
                            currentChannel.Close();
                        }
                        if (_channelFactory != null)
                        {
                            ((IDisposable)_channelFactory).Dispose();
                        }
                        _channel = null;
                        _channelFactory = null;
                    }
                }
            }
            _disposed = true;           
        }

        
    }
}
