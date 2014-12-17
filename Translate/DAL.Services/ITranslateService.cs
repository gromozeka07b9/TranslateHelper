using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Translate.DAL.Services
{
    public interface ITranslateService
    {
        OperationResult<string> TranslateString(string sourceString, string directionFrom, string directionTo);
        OperationResult<string> TranslateArrayStrings(IEnumerable<string> sourceArrayStrings , string directionFrom, string directionTo);
    }
}
