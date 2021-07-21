using Newtonsoft.Json;

namespace DictionaryKit.Models
{
    public class Xiehouyu
    {
        [JsonProperty("riddle")]
        public string Riddle { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }
    }
}
