
using Newtonsoft.Json;

namespace DictionaryKit.Models
{
    public class Ci : IChineseObject
    {
        [JsonProperty("ci")]
        public string CiContent { get; set; }

        [JsonProperty("explanation")]
        public string Explanation { get; set; }

        public string GetSearchContent(bool isStrict) => isStrict ? CiContent : $"{CiContent}{Explanation}";

        public override string ToString() => $"【词语】{CiContent}\n【解释】\n{Explanation}\n";
    }
}
