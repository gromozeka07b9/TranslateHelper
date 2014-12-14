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
    public class BlTests
    {

        [TestMethod]
        public void CreateWordColocation_AddOneWordsPass()
        {
            var initParam = new InitTests();
            var wc = initParam.GetDefaultWordColocation();
            var words = wc.OriginalWords;
            List<string> wordForCheck = initParam.GetDefaultWordsKit1();
            int index = 0;
            foreach (var item in wordForCheck)
            {
                Assert.IsTrue(words[index] == item);
                index++;
            }
            Assert.IsTrue(wordForCheck.Count == words.Count);
        }





    }
}
