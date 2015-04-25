namespace Newtonsoft.Json.Linq
{
    using System.Collections.Generic;
    using System.Linq;

    static internal class JTokenExtensions
    {
        public static List<string> GetPropertyNames(this JToken token)
        {
            if (token.Type == JTokenType.Object)
            {
                return ((JObject) token).Properties().Select(p => p.Name).ToList();
            }
            return new List<string>();
        }
    }
}