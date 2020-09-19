using Newtonsoft.Json;

namespace Engineering.UAFClientConnectorLibrary
{
    static class JSONSerializer
    {
        public static string Serialize<TClass>(TClass value)
        {
            return JsonConvert.SerializeObject(value);
        }
        public static TClass Deserialize<TClass>(string value)
        {
            return JsonConvert.DeserializeObject<TClass>(value);
        }

    }
}
