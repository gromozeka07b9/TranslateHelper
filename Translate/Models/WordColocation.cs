using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate.Models
{
    public class WordColocation : IWordColocation
    {
        List<OneWord> listWords = new List<OneWord>();
        string wordColocationTranslated = string.Empty;
        TranslateDirection direction;

        public WordColocation(TranslateDirection translateDirection)
        {
            direction = translateDirection;
        }

        public int GetWordsCount()
        {
 	        throw new NotImplementedException();
        }

        public List<OneWord> GetWords()
        {
            return listWords;
        }

        public void AddWord(string oneWord)
        {
            listWords.Add(new OneWord(oneWord));
        }

        public TranslateDirection GetTranslateDirection()
        {
            return direction;
        }

    }
}
