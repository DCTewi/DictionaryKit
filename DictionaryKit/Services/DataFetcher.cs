using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryKit.Models;
using Newtonsoft.Json;

namespace DictionaryKit.Services
{
    public class DataFetcher
    {
        private const string DataPath = "DictionaryData/data";
        private const string CiFileName = "ci.json";
        private const string IdiomFileName = "idiom.json";
        private const string WordFileName = "word.json";
        private const string XiehouyuFileName = "xiehouyu.json";

        public enum DataType
        {
            Ci = 0,
            Idiom = 1,
            Word = 2,
            Xiehouyu = 3,
        }

        public enum DataType_Localization // 时间紧, 不好好写了
        {
            词语 = 0,
            成语 = 1,
            汉字 = 2,
            歇后语 = 3,
        }

        private static string GetPath(DataType dataType)
        {
            var result = Path.Combine(Path.GetFullPath("."), DataPath, dataType switch
            {
                DataType.Ci => CiFileName,
                DataType.Idiom => IdiomFileName,
                DataType.Word => WordFileName,
                DataType.Xiehouyu => XiehouyuFileName,
                _ => "",
            });

            return result;
        }

        public static List<Ci> GetCis()
        {
            var rawJson = File.ReadAllText(GetPath(DataType.Ci));

            return JsonConvert.DeserializeObject<List<Ci>>(rawJson);
        }

        public static List<Idiom> GetIdioms()
        {
            var rawJson = File.ReadAllText(GetPath(DataType.Idiom));

            return JsonConvert.DeserializeObject<List<Idiom>>(rawJson);
        }

        public static List<Word> GetWords()
        {
            var rawJson = File.ReadAllText(GetPath(DataType.Word));

            return JsonConvert.DeserializeObject<List<Word>>(rawJson);
        }

        public static List<Xiehouyu> GetXiehouyus()
        {
            var rawJson = File.ReadAllText(GetPath(DataType.Xiehouyu));

            return JsonConvert.DeserializeObject<List<Xiehouyu>>(rawJson);
        }

    }
}
