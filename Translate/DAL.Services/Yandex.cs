using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translate.Models;

namespace Translate.DAL.Services
{
    public class Yandex : ITranslateService
    {
        public Yandex()
        {
        }

        public OperationResult<string> TranslateString(string sourceString, string directionFrom, string directionTo)
        {
            var result = new OperationResult<string>(string.Empty, string.Empty);
            throw  new Exception("Not realized");
            return result;
        }
    }
}
