using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Translate.TranslateDataSetTableAdapters;
//using System.Windows.Forms;

namespace Translate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindowOld : Window
    {
        TranslateService CurrentService = TranslateService.Bing;

        public MainWindowOld()
        {
            InitializeComponent();
        }

        private void richSource_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void richSource_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OperationResult<List<string>> result = TranslateString(richSource.Selection.Text);
            if (string.IsNullOrEmpty(result.Error))
            {
                if (result.Value.Count() > 0)
                {
                    TextBlock tb = new TextBlock();
                    tb.Text = richSource.Selection.Text + ": " + result.Value[0];
                    RecentWords.Items.Add(tb);
                }
                //richSource.Selection.Text = result.Value.First<string>();
            }
            else
            {
                MessageBox.Show("Ошибка вызова сервиса перевода: " + result.Error);
            }
        }

        private OperationResult<List<string>> TranslateString(string ToTranslate)
        {
            OperationResult<List<string>> result = new OperationResult<List<string>>(new List<string>(), string.Empty);
            if (!string.IsNullOrEmpty(ToTranslate))
            {
                switch (CurrentService)
                {
                    case TranslateService.Bing:
                        {
                            TranslateBing Bing = new TranslateBing(TranslateFromTo.EnRu);
                            result = Bing.Translate(ToTranslate);
                        }; break;
                    case TranslateService.Yandex:
                        {
                        }; break;
                    default:
                        {
                            result.Error = "Необходимо задать сервис перевода!";
                        }; break;
                }
            }
            else
            {
                result.Error = "Текст для перевода отсутствует!";
            }
            return result;
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("пока не работает");
        }

        private void bTranslateBlock_Click(object sender, RoutedEventArgs e)
        {
            /*OperationResult<List<string>> result = TranslateString(richSource.Selection.Text);
            if (string.IsNullOrEmpty(result.Error))
            {
                TextBlock tb = new TextBlock();
                tb.Text = richSource.Selection.Text + ": " + result.Value;
                RecentWords.Items.Add(tb);
                richSource.Selection.Text = result.Value.First<string>();
            }
            else
            {
                MessageBox.Show("Ошибка вызова сервиса перевода: " + result.Error);
            }*/
        }

        private void cbTranslateService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((cbTranslateService.SelectedItem as ComboBoxItem).Name)
            {
                case "cbYandex":
                    {

                        CurrentService = TranslateService.Yandex;
                    };break;
                case "cbBing":
                    {
                        TranslateBing testBing = new TranslateBing(TranslateFromTo.EnRu);
                        var test = testBing.Test();
                        if (string.IsNullOrEmpty(test.Error))
                            CurrentService = TranslateService.Bing;
                        else MessageBox.Show("Сервис недоступен! Ошибка: " + test.Error);
                    }; break;
                default:
                    {
                    }; break;
            }
        }

        private void bToElements_Click(object sender, RoutedEventArgs e)
        {
            //string ToTranslateString = "hello world hello world hello world hello world hello world hello world hello world hello world hello world hello world hello world hello world hello world hello world hello world hello world hello world hello world hello world ";
            List<string> LineList = TransformTextToElements(richSource.Selection.Text);
            //List<string> LineList = TransformTextToElements(ToTranslateString);
            //TransformTextLinesToElements(LineList);
        }

        private string TranslateTextLines(List<string> LineList)
        {
            string Error = string.Empty;
            foreach(string Line in LineList)
            {
                StackPanel newPanel = new StackPanel();
                newPanel.Orientation = Orientation.Horizontal;
                string[] arrWords = Line.Split("".ToCharArray());
                foreach (string oneWord in arrWords)
                {
                    ComboBox BoxOneWord = new ComboBox();
                    ComboBoxItem BoxItem = new ComboBoxItem();
                    BoxItem.Content = oneWord;
                    BoxOneWord.Items.Add(BoxItem);
                    BoxOneWord.SelectedIndex = 0;
                    BoxOneWord.IsEditable = true;

                    /*TranslateBing Bing = new TranslateBing(TranslateFromTo.EnRu);
                    string ReplacedString = RemoveSymbols(oneWord);
                    OperationResult<List<string>> result = Bing.Translate(ReplacedString);
                    if (!string.IsNullOrEmpty(result.Error))
                    {
                        Error = result.Error;
                        break;
                    }
                    else
                    {
                        //перевод уже в базе
                    }*/
                }
            }
            return Error;
        }

        private string RemoveSymbols(string oneWord)
        {
            string result = oneWord.Replace(",", string.Empty);
            result = result.Replace(".", string.Empty);
            result = result.Replace("!", string.Empty);
            result = result.Replace("?", string.Empty);
            result = result.Replace(":", string.Empty);
            result = result.Replace("'", string.Empty);
            result = result.Replace("_", string.Empty);
            result = result.Replace(@"""", string.Empty);
            return result;
        }

        private List<string> TransformTextToElements(string InputText)
        {
            int MaxCountWordsInLine = 20;//Максимум длины строки в словах
            List<string> PostTransformLines = new List<string>();
            //сначала разберем на слова, потом соберем строки
            string[] Words = InputText.Split(" ".ToCharArray());
            int index = 0;
            string Line = string.Empty;
            foreach (string oneWord in Words)
            {
                if (index < MaxCountWordsInLine)
                {
                    if (Line != string.Empty) Line += " ";
                    Line += oneWord;
                    index++;
                }
                else
                {
                    string[] findNewLineArr = Line.Split(Environment.NewLine.ToCharArray());
                    foreach (string newLine in findNewLineArr)
                    {
                        if (string.Empty!=newLine)
                        PostTransformLines.Add(newLine);
                    }
                    Line = string.Empty + oneWord;
                    index = 0;
                }
            }
            return PostTransformLines;
        }

        private void RecentWords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void richSource_TextChanged(object sender, TextChangedEventArgs e)
        {
            richSource.SelectAll();
            List<string> LineList = TransformTextToElements(richSource.Selection.Text);
            string Error = TranslateTextLines(LineList);
            if (!string.IsNullOrEmpty(Error))
                MessageBox.Show(Error);
            else MessageBox.Show("Готово");
        }
    }
}
