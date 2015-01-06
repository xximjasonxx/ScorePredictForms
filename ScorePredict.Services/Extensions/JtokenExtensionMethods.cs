using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ScorePredict.Services
{
    public static class JtokenExtensionMethods
    {
        public static IDictionary<string, string> AsDictionary(this JToken token)
        {
            return token.Children<JProperty>()
                .ToDictionary(x => x.Name, x => x.Value.ToString());
        }
    }
}

