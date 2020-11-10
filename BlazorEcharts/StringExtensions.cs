using Newtonsoft.Json.Linq;

namespace BlazorEcharts
{
    public static class StringExtensions
    {
        public static JRaw ToJsFunction(this string functionString)
        {
            return new JRaw(functionString);
        }
    }
}