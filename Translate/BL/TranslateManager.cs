using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translate.BL;
using Translate.Models;

namespace Translate.BL
{
    public class TranslateManager : ITranslateManager
    {
        string textOriginal;
        TranslateDirection translateDirection;

        public TranslateManager(string textForTraslate, TranslateDirection direction)
        {
            textOriginal = textForTraslate;
            translateDirection = direction;
        }

        public List<WordColocation> TranslateSeparatedWords()
        {
            var resultList = new List<WordColocation>();
            string[] parsedTextArr = ParseInputString(textOriginal, translateDirection);
            foreach(var str in parsedTextArr)
            {
                var newWord = new WordColocation(translateDirection);
                newWord.AddWord(str);
                Bing translater = new Bing(translateDirection);
                var translateResult = translater.Translate(str);
                if(string.IsNullOrEmpty(translateResult.Error))
                {
                    //newWord.
                }
                resultList.Add(newWord);
            }
            return resultList;
        }

        private string[] ParseInputString(string textOriginal, TranslateDirection translateDirection)
        {
            //разделители - пробелы и переводы строк, пока без переносов
            char[] delimiters = {' ','\n'};
            return textOriginal.Split(delimiters);
        }

        public WordColocation TranslateColocatedWords()
        {
            throw new NotImplementedException();
        }
    }
}
