
using Newtonsoft.Json;

namespace DictionaryKit.Models
{
    public class Ci
    {
        [JsonProperty("ci")]
        public string CiContent { get; set; }

        [JsonProperty("explanation")]
        public string Explanation { get; set; }
    }
}
