using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate.Models
{
    public class WordColocation : IWordColocation
    {
        List<string> listOriginalWords = new List<string>();
        TranslatedStrings translatedStrings;

        public List<string> OriginalWords
        {
            get
            {
                return listOriginalWords;
            }
        }

        public TranslatedStrings TranslateResult
        {
            get
            {
                return translatedStrings;
            }
        }

        public WordColocation()
        {          
        }

        public void AddOriginalWord(string oneWord)
        {
            listOriginalWords.Add(oneWord);
        }

        public void SetTranslateResult(TranslatedStrings translateResult)
        {
            translatedStrings = translateResult;
        }

    }
}
