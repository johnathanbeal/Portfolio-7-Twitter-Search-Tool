using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace API.NewtonsoftIkkyo
{
    public class NewtonsoftJsonIkkyo
    {
        public static List<JProperty> ResponseJsonKeyValue(string json)
        {
            //string json = "{'results':[{'SwiftCode':'','City':'','BankName':'Deutsche    Bank','Bankkey':'10020030','Bankcountry':'DE'},{'SwiftCode':'','City':'10891    Berlin','BankName':'Commerzbank Berlin (West)','Bankkey':'10040000','Bankcountry':'DE'}]}";

            List<JProperty> properties = new List<JProperty>();

            var resultObjects = AllChildren(JObject.Parse(json))
                .First(c => c.Type == JTokenType.Array && c.Path.Contains("results"))
                .Children<JObject>();

            foreach (JObject result in resultObjects)
            {
                foreach (JProperty property in result.Properties())
                {
                    properties.Add(property);
                }
            }
            return properties;
        }

        // recursively yield all children of json
        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }
    }
}

