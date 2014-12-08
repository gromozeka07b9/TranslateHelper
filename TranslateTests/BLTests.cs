using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translate.Models;
using System.Collections.Generic;
using System.Text;
using TranslateTests;
using Translate.BL;

namespace TranslateTests
{
    [TestClass]
    public class BLTests
    {

        [TestMethod]
        public void CreateWordColocation_AddWordsPass()
        {
            WordColocation wc = getDefaultWordColocation(new TranslateDirection(TranslateDirectionEnum.Ru_En));
            var words = wc.GetWords();
            List<string> wordForCheck = getDefaultWordsKit1();
            int index = 0;
            foreach (var item in wordForCheck)
            {
                Assert.IsTrue(words[index].WordOriginal == item);
                index++;
            }
            Assert.IsTrue(wc.GetTranslateDirection().Direction == TranslateDirectionEnum.Ru_En);
        }

        [TestMethod]
        public void TranslateManager_LoadWordsPass()
        {           
            var manager = new TranslateManager(getDefaultTextForTranslateKit1(), new TranslateDirection(TranslateDirectionEnum.Ru_En));
            List<WordColocation> listWordsColocation = manager.TranslateSeparatedWords();
            //WordColocation wordsColocation = manager.TranslateColocatedWords();

            /*int index = 0;
            foreach (var item in wordForCheckKit1)
            {
                Assert.IsTrue(words[index].WordOriginal == item);
                index++;
            }
            Assert.IsTrue(wc.GetTranslateDirection() == TranslateDirection.Ru_En);*/
        }

        private WordColocation getDefaultWordColocation(TranslateDirection direction)
        {
            List<string> wordForCheck = getDefaultWordsKit1();
            WordColocation wc = new WordColocation(direction);
            foreach (var item in wordForCheck)
            {
                wc.AddWord(item);
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
