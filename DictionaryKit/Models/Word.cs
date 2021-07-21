using Newtonsoft.Json;
using System.Collections.Generic;

namespace DictionaryKit.Models
{
    public class Word
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
    }
}
