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
        readonly TranslateDirections _translateDirection;
        readonly TranslateService _translateService;

        public TranslateManager(TranslateDirections direction, TranslateService service)
        {
            _translateDirection = direction;
            _translateService = service;
        }

        public WordColocation Translate(string textOriginal)
        {
            var translatedWords = new WordColocation();
            string[] parsedTextArr = ParseInputString(textOriginal, _translateDirection);
            foreach(var item in parsedTextArr)
            {
                translatedWords.AddOriginalWord(item);
            }
            
            TranslateServiceManager servManager = new TranslateServiceManager();
            ITranslateService srvTranslate = null;
            switch(_translateService.Service)
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
            var callServiceResult = servManager.Translate(srvTranslate, textOriginal, _translateDirection.From, _translateDirection.To);
            if (string.IsNullOrEmpty(callServiceResult.Error))
            {
                var ts = new TranslatedStrings(_translateDirection);
                ts.ListWords.Add(callServiceResult.Value);
                translatedWords.SetTranslateResult(ts);
            }
            return translatedWords;
        }

        private string[] ParseInputString(string textOriginal, TranslateDirections translateDirection)
        {
            //разделители - пробелы и переводы строк, пока без переносов
            char[] delimiters = {' ','\n'};
            return textOriginal.Split(delimiters);
        }
    }
}
