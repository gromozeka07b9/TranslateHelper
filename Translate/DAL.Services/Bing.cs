using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translate.Models;

namespace Translate
{
    public class Bing : AbstractTranslateService
    {
        public Bing(TranslateDirection translateDirection) 
        {
            direction = translateDirection;
        }

        public override OperationResult<List<string>> Translate(string sourceString)
        {
            OperationResult<List<string>> result = new OperationResult<List<string>>(new List<string>(), string.Empty);
            RefBing.LanguageServiceClient client = new RefBing.LanguageServiceClient();
            try
            {
                if (null != direction)
                {
                    string TranslatedString = client.Translate("0256C6925C368EC83FAD276B2ED2706F709CC4D1", sourceString, direction.From, direction.To, "", "");
                    if (string.Empty != TranslatedString)
                    {
                        result.Value.Add(TranslatedString);
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
