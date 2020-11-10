using Microsoft.JSInterop;
using System;

namespace BlazorEcharts
{
    public class EchartsEventInvokeHelper
    {
        private readonly Action<EchartsEventArgs> _action;

        public EchartsEventInvokeHelper(Action<EchartsEventArgs> action)
        {
            _action = action;
        }

        [JSInvokable]
        public void EchartsEventCaller(EchartsEventArgs args)
        {
            _action.Invoke(args);
        }
    }
}