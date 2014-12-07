using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Translate.Models
{
    public class OneWord
    {
        string wordOriginal;
        string wordTranslated;

        public string WordOriginal
        {
            get
            {
                return wordOriginal;
            }
        }

        /// <summary>
        /// Строка после перевода
        /// </summary>
        public string WordTranslated
        {
            get
            {
                return wordTranslated;
            }
            set
            {
                wordTranslated = value;
            }
        }

        public OneWord(string originalWord)
        {
            wordOriginal = originalWord;
        }
    }
}
