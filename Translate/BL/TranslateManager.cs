using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translate.BL;
using Translate.Models;

namespace TranslateTests.BL
{
    public class TranslateManager : ITranslateManager
    {
        //private string textOri;
        //private TranslateDirection translateDirection;

        public TranslateManager(string textForTraslate, Translate.Models.TranslateDirection translateDirection)
        {
            // TODO: Complete member initialization
            //this.textForTraslate = textForTraslate;
            //this.translateDirection = translateDirection;
        }

        public List<WordColocation> TranslateSeparatedWords()
        {
            throw new NotImplementedException();
        }

        public WordColocation TranslateWordColocation()
        {
            throw new NotImplementedException();
        }
    }
}
