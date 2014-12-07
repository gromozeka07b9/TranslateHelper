using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate.Models
{
    /// <summary>
    /// интерфейс описывает одно предложение из нескольких слов
    /// из интерфейса должно быть понятно:
    /// сколько слов
    /// исходный язык
    /// конечный язык
    /// сами слова по отдельности
    /// "Это пример предложения"
    /// </summary>
    interface IWordColocation
    {
        int GetWordsCount();

        List<OneWord> GetWords();

        void AddWord(string oneWord);

        TranslateDirection GetTranslateDirection();

    }
}
