using Newtonsoft.Json;

namespace SQLite
{
    public class Category
    {
        [JsonProperty(PropertyName = "id")]
        public string Id;

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "__version")]
        public string Version { set; get; }
    }
}