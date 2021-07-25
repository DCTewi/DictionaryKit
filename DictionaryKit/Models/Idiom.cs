using Newtonsoft.Json;

namespace DictionaryKit.Models
{
    /// <summary>
    /// 成语
    /// </summary>
    public class Idiom : IChineseObject
    {
        /// <summary>
        /// 出处
        /// </summary>
        [JsonProperty("derivation")]
        public string Derivation { get; set; }

        /// <summary>
        /// 示例
        /// </summary>
        [JsonProperty("example")]
        public string Example { get; set; }

        /// <summary>
        /// 解释
        /// </summary>
        [JsonProperty("explanation")]
        public string Explanation { get; set; }

        /// <summary>
        /// 拼音
        /// </summary>
        [JsonProperty("pinyin")]
        public string Pinyin { get; set; }

        /// <summary>
        /// 成语
        /// </summary>
        [JsonProperty("word")]
        public string Word { get; set; }

        /// <summary>
        /// 首字母缩写
        /// </summary>
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        public string GetSearchContent(bool isStrict) => isStrict ? Word + Pinyin : $"{Pinyin}{Word}{Explanation}";

        public override string ToString() => $"【成语】{Word} ({Pinyin})\n【出处】\n{Derivation}\n【解释】\n{Explanation}\n【示例】\n{Example}\n";
    }
}
