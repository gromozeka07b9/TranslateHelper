using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Translate.Models
{
    class WordModel
    {
        /// <summary>
        /// Представляет собой исходную строку, до перевода
        /// </summary>
        public string StringOriginal { get; set; }
        
        /// <summary>
        /// Строка после перевода
        /// </summary>
        public string StringTranslated { get; set; }

        /// <summary>
        /// Тип перевода Ru-En, En-Ru
        /// </summary>
        public string TranslateType { get; set; }

    }
}
