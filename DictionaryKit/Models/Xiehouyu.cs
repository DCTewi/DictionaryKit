using Newtonsoft.Json;

namespace DictionaryKit.Models
{
    public class Xiehouyu : IChineseObject
    {
        [JsonProperty("riddle")]
        public string Riddle { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }

        public string GetSearchContent(bool isStrict) => $"{Riddle}{Answer}";

        public override string ToString() => $"{Riddle} - {Answer}\n";
    }
}
