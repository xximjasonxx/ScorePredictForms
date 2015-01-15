using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ScorePredict.Services.Extensions
{
    public static class JtokenExtensionMethods
    {
        public static IDictionary<string, string> AsDictionary(this JToken token)
        {
            return token.Children<JProperty>()
                .ToDictionary(x => x.Name, x => x.Value.ToString());
        }

        public static JObject AsJObject(this IDictionary<string, string> dictionary)
        {
            var jo = new JObject();
            foreach (var kv in dictionary)
            {
                jo.Add(kv.Key, kv.Value);
            }

            return jo;
        }
    }
}

