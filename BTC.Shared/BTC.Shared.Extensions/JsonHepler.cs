using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTC.Shared.Extensions
{
    public static class JsonHepler
    {
        public static T Json<T>(this string json) where T : class, new()
        {
            var jobject = JObject.Parse(json);
            return JsonConvert.DeserializeObject<T>(jobject.ToString());
        }
    }
}
