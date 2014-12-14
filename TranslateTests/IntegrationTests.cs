using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translate.BL;
using Translate.DAL.Services;

namespace TranslateTests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void TranslateManager_Bing_TranslateManyWordsPass()
        {
            var initParam = new InitTests();
            var manager = new TranslateManager(new TranslateDirections(TranslateDirectionEnum.Ru_En), new TranslateService(TranslateServiceEnum.Bing));
            var result = manager.Translate(initParam.GetDefaultTextForTranslateKit1());

            var index = 0;
            foreach (var item in initParam.GetDefaultWordsKit1())
            {
                Assert.IsTrue(result.OriginalWords[index] == item);
                index++;
            }
            Assert.IsTrue(result.TranslateResult.ListWords[0] == "a review of proposals");
        }

        [TestMethod]
        public void TranslateManager_Bing_TranslateOneWordsPass()
        {
            var manager = new TranslateManager(new TranslateDirections(TranslateDirectionEnum.Ru_En), new TranslateService(TranslateServiceEnum.Bing));
            var result = manager.Translate("Проверка");
            Assert.IsTrue(result.TranslateResult.ListWords[0] == "Check");
        }
    }
}
