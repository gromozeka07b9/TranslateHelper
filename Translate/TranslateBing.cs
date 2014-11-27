using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Translate
{
    class TranslateBing : TranslateClass
    {
        public TranslateBing(TranslateFromTo FromTo)
        {
            this.Service = TranslateService.Bing;
            this.FromTo = FromTo;
        }

        public override OperationResult<List<string>> Translate(string OriginalString)
        {
            OperationResult<List<string>> result = new OperationResult<List<string>>(new List<string>(), string.Empty);
            RefBing.LanguageServiceClient client = new RefBing.LanguageServiceClient();
            try
            {
                string From = string.Empty;
                string To = string.Empty;
                switch (FromTo)
                {
                    case TranslateFromTo.EnRu:
                        {
                            From = "en";
                            To = "ru";
                        };break;
                    case TranslateFromTo.RuEn:
                        {
                            From = "ru";
                            To = "en";
                        }; break;
                    default:
                        {
                        }; break;
                }
                if (FromTo != TranslateFromTo.NotSet)
                {
                    OperationResult<List<string>> CacheResult = GetTranslatedStrinsFormLocalDB(OriginalString);
                    if (CacheResult.Value.Count > 0)
                    {
                        result.Value = CacheResult.Value;
                    }
                    else
                    {
                        string TranslatedString = client.Translate("0256C6925C368EC83FAD276B2ED2706F709CC4D1", OriginalString, From, To, "", "");
                        if (string.Empty != TranslatedString)
                        {
                            result.Value.Add(this.Service + ": " + TranslatedString);
                            //добавим слово в кеш
                            SaveTranslatedWordToCache(OriginalString, TranslatedString);
                        }
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
