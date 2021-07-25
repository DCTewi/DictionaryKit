using Newtonsoft.Json;
using System.Collections.Generic;

namespace DictionaryKit.Models
{
    public class Word : IChineseObject
    {
        [JsonProperty("word")]
        public string WordContent { get; set; }

        [JsonProperty("oldword")]
        public string OldWord { get; set; }

        [JsonProperty("strokes")]
        public string Strokes { get; set; }

        [JsonProperty("pinyin")]
        public string Pinyin { get; set; }

        [JsonProperty("radicals")]
        public string Radicals { get; set; }

        [JsonProperty("explanation")]
        public string Explanation { get; set; }

        /// <summary>
        /// more = 更多
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();

        public string GetSearchContent(bool isStrict) => isStrict ? WordContent + OldWord + Pinyin : $"{WordContent}{OldWord}{Pinyin}{Explanation}";

        public override string ToString() => $"【汉字】{WordContent} ({Pinyin})\n【繁体】{OldWord}\n【解释】\n{Explanation}\n";
    }
}
