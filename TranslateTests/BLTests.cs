using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translate.Models;
using System.Collections.Generic;
using System.Text;
using TranslateTests;
using Translate.BL;
using Translate.DAL.Services;

namespace TranslateTests
{
    [TestClass]
    public class BLTests
    {

        [TestMethod]
        public void CreateWordColocation_AddOneWordsPass()
        {
            WordColocation wc = getDefaultWordColocation();
            var words = wc.OriginalWords;
            List<string> wordForCheck = getDefaultWordsKit1();
            int index = 0;
            foreach (var item in wordForCheck)
            {
                Assert.IsTrue(words[index] == item);
                index++;
            }
            Assert.IsTrue(wordForCheck.Count == words.Count);
        }

        [TestMethod]
        public void TranslateManager_AddManyWordsPass()
        {           
            var manager = new TranslateManager(new TranslateDirections(TranslateDirectionEnum.Ru_En), new TranslateService(TranslateServiceEnum.Bing));
            var result = manager.Translate(getDefaultTextForTranslateKit1());

            //List<WordColocation> listWordsColocation = manager.TranslateSeparatedWords();
            //WordColocation wordsColocation = manager.TranslateColocatedWords();

            /*int index = 0;
            foreach (var item in wordForCheckKit1)
            {
                Assert.IsTrue(words[index].WordOriginal == item);
                index++;
            }
            Assert.IsTrue(wc.GetTranslateDirection() == TranslateDirection.Ru_En);*/
        }

        private WordColocation getDefaultWordColocation()
        {
            List<string> wordForCheck = getDefaultWordsKit1();
            WordColocation wc = new WordColocation();
            foreach (var item in wordForCheck)
            {
                wc.AddOriginalWord(item);
            }
            return wc;
        }

        private List<string> getDefaultWordsKit1()
        {
            List<string> words = new List<string>();
            words.Add("это");
            words.Add("проверка");
            words.Add("состава");
            words.Add("предложения");
            return words;
        }

        private string getDefaultTextForTranslateKit1()
        {
            var words = getDefaultWordsKit1();
            StringBuilder sb = new StringBuilder();
            foreach(var item in words)
            {
                sb.Append(item);
                sb.Append(" ");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
