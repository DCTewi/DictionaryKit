namespace DictionaryKit.Models
{
    public class Condition
    {
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
    }
}
