using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translate.Models;

namespace Translate.DAL.Services
{
    public class Bing : ITranslateService
    {
        public Bing() 
        {
        }

        public OperationResult<string> TranslateString(string sourceString, string directionFrom, string directionTo)
        {
            OperationResult<string> result = new OperationResult<string>(string.Empty, string.Empty);
            RefBing.LanguageServiceClient client = new RefBing.LanguageServiceClient();
            try
            {
                if ((!string.IsNullOrEmpty(directionFrom)) && (!string.IsNullOrEmpty(directionTo)))
                {
                    string TranslatedString = client.Translate("0256C6925C368EC83FAD276B2ED2706F709CC4D1", sourceString, directionFrom, directionTo, "", "");
                    if (string.Empty != TranslatedString)
                    {
                        result.Value = TranslatedString;
                    }
                }
                else
                {
                    result.Error = "Необходимо задать направление перевода!";
                }
            }
            catch (Exception E)
            {
                result.Error = E.Message;
            }
            return result;
        }
    }
}
