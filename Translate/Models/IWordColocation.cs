﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate.Models
{
    /// <summary>
    /// </summary>
    interface IWordColocation
    {

        void AddOriginalWord(string oneWord);

        void SetTranslateResult(TranslatedStrings translateResult);

    }
}
