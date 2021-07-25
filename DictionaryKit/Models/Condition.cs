namespace DictionaryKit.Models
{
    public class Condition
    {
        public const string Tones = "" +
            "āōēīū\n" +
            "áóéíú\n" +
            "ǎǒěǐǔ\n" +
            "àòèìù\n" +
            "aoeiuü";

        public enum ConditionType
        {
            Required,
            Optional,
        }

        public enum ConditionType_Localization
        {
            必须包含,
            至少一个,
        }

        public ConditionType Type { get; set; }

        public string Content { get; set; }

        public override string ToString()
        {
            return $"{(ConditionType_Localization)Type} | {Content}";
        }
    }
}
