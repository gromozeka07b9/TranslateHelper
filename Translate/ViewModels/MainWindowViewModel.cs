using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using Translate.Models;

namespace Translate.ViewModels
{
    class MainWindowViewModel
    {
        public List<WordModel> Words { get; set; }

        #region Constructor
        public MainWindowViewModel()
        {
            ClickOnWordCommand = new Command(arg => ClickOnWordMethod());
            Words = new List<WordModel>();
            Words.Add(new WordModel(){StringOriginal="original", StringTranslated="перевод", TranslateType="тест" });
            Words.Add(new WordModel(){StringOriginal="original1", StringTranslated="перевод", TranslateType="тест" });
            Words.Add(new WordModel(){StringOriginal="original2", StringTranslated="перевод", TranslateType="тест" });
            Words.Add(new WordModel(){StringOriginal="original3", StringTranslated="перевод", TranslateType="тест" });

            /*WordColocation wc = new WordColocation(TranslateDirection.Ru_En);
            wc.AddWord("это");
            wc.AddWord("проверка");
            wc.AddWord("состава");
            wc.AddWord("предложения");*/
        }
        #endregion 

        #region Commands
        public static ICommand ClickOnWordCommand { get; set; }
        #endregion

        #region Methods
        private void ClickOnWordMethod()
        {
            MessageBox.Show("click");
        }
        #endregion

    }
}
