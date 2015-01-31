using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ScorePredict.Services.Extensions
{
    public static class JtokenExtensionMethods
    {
        public static IList<IDictionary<string, string>> AsDictionary(this JToken token)
        {
            var asJObject = token as JObject;
            if (asJObject != null)
            {
                return new List<IDictionary<string, string>>()
                {
                    asJObject.Children<JProperty>().ToDictionary(x => x.Name, x => x.Value.ToString())
                };
            }

            return token.AsJEnumerable().Select(je => je.Children<JProperty>()
                .ToDictionary(x => x.Name, x => x.Value.ToString()))
                .Cast<IDictionary<string, string>>().ToList();
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

