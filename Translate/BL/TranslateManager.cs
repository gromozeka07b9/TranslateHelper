using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translate.BL;
using Translate.DAL.Services;
using Translate.Models;

namespace Translate.BL
{
    public class TranslateManager : ITranslateManager
    {
        readonly TranslateDirections translateDirection;
        readonly TranslateService translateService;

        public TranslateManager(TranslateDirections direction, TranslateService service)
        {
            translateDirection = direction;
            translateService = service;
        }

        public WordColocation Translate(string textOriginal)
        {
            var translatedWords = InitArrayTranslatedWords(textOriginal);
            var srvTranslate = SelectTranslateService();
            var callServiceResult = srvTranslate.TranslateString(textOriginal, translateDirection.From, translateDirection.To);
            if (string.IsNullOrEmpty(callServiceResult.Error))
            {
                var tsResult = new TranslatedStrings(translateDirection);
                tsResult.ListWords.Add(callServiceResult.Value);
                translatedWords.SetTranslateResult(tsResult);
            }
            return translatedWords;
        }

        private ITranslateService SelectTranslateService()
        {
            ITranslateService srvTranslate = null;
            switch (translateService.Service)
            {
                case TranslateServiceEnum.Bing:
                    {
                        srvTranslate = new Bing();
                    };
                    break;
                case TranslateServiceEnum.Yandex:
                    {
                        srvTranslate = new Yandex();
                    };
                    break;
                default:
                    {
                        srvTranslate = new Bing();
                    };
                    break;
            }
            return srvTranslate;
        }

        private WordColocation InitArrayTranslatedWords(string textOriginal)
        {
            var translatedWords = new WordColocation();
            var parsedTextArr = ParseInputString(textOriginal, translateDirection);
            foreach (var item in parsedTextArr)
            {
                translatedWords.AddOriginalWord(item);
            }
            return translatedWords;
        }

        private IEnumerable<string> ParseInputString(string textOriginal, TranslateDirections translateDirection)
        {
            //разделители - пробелы и переводы строк, пока без переносов
            char[] delimiters = { ' ', '\n' };
            return textOriginal.Split(delimiters);
        }
    }
}
