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
            var translatedWords = new WordColocation();
            IEnumerable<string> parsedTextArr = ParseInputString(textOriginal, translateDirection);
            foreach(var item in parsedTextArr)
            {
                translatedWords.AddOriginalWord(item);
            }
            
            var servManager = new TranslateServiceManager();
            ITranslateService srvTranslate = null;
            switch(translateService.Service)
            {
                case TranslateServiceEnum.Bing:
                    {
                        srvTranslate = new Bing();
                    };break;
                case TranslateServiceEnum.Yandex:
                    {
                        srvTranslate = new Yandex();
                    }; break;
                default:
                    {
                        srvTranslate = new Bing();
                    }; break;
            }
            var callServiceResult = servManager.Translate(srvTranslate, textOriginal, translateDirection.From, translateDirection.To);
            if (string.IsNullOrEmpty(callServiceResult.Error))
            {
                var ts = new TranslatedStrings(translateDirection);
                ts.ListWords.Add(callServiceResult.Value);
                translatedWords.SetTranslateResult(ts);
            }
            return translatedWords;
        }

        private IEnumerable<string> ParseInputString(string textOriginal, TranslateDirections translateDirection)
        {
            //разделители - пробелы и переводы строк, пока без переносов
            char[] delimiters = {' ','\n'};
            return textOriginal.Split(delimiters);
        }
    }
}
