using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translate.Models;

namespace TranslateTests
{
    public class InitTests
    {
        public WordColocation GetDefaultWordColocation()
        {
            List<string> wordForCheck = GetDefaultWordsKit1();
            WordColocation wc = new WordColocation();
            foreach (var item in wordForCheck)
            {
                wc.AddOriginalWord(item);
            }
            return wc;
        }

        public List<string> GetDefaultWordsKit1()
        {
            List<string> words = new List<string>();
            words.Add("это");
            words.Add("проверка");
            words.Add("состава");
            words.Add("предложения");
            return words;
        }

        public string GetDefaultTextForTranslateKit1()
        {
            var words = GetDefaultWordsKit1();
            StringBuilder sb = new StringBuilder();
            foreach (var item in words)
            {
                sb.Append(item);
                sb.Append(" ");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
