using Microsoft.JSInterop;
using Newtonsoft.Json;
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
        public void EchartsEventCaller(string args)
        {
            _action.Invoke(JsonConvert.DeserializeObject<EchartsEventArgs>(args));
        }
    }
}