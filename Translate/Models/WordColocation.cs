using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate.Models
{
    public class WordColocation : IWordColocation
    {
        public List<string> OriginalWords { get; private set; }

        public TranslatedStrings TranslateResult { get; private set; }

        public WordColocation()
        {
            OriginalWords = new List<string>();
        }

        public void AddOriginalWord(string oneWord)
        {
            OriginalWords.Add(oneWord);
        }

        public void SetTranslateResult(TranslatedStrings translateResult)
        {
            TranslateResult = translateResult;
        }

    }
}
