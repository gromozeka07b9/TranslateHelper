using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate.Models
{
    public class WordColocation : IWordColocation
    {
        readonly List<string> _listOriginalWords = new List<string>();
        TranslatedStrings _translatedStrings;

        public List<string> OriginalWords
        {
            get
            {
                return _listOriginalWords;
            }
        }

        public TranslatedStrings TranslateResult
        {
            get
            {
                return _translatedStrings;
            }
        }

        public WordColocation()
        {          
        }

        public void AddOriginalWord(string oneWord)
        {
            _listOriginalWords.Add(oneWord);
        }

        public void SetTranslateResult(TranslatedStrings translateResult)
        {
            _translatedStrings = translateResult;
        }

    }
}
