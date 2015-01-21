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
using System.Windows.Shapes;
using Translate.Models;
using TranslateCustomControls;

namespace Translate.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<WordModel> StringControlList = new List<WordModel>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //StringControlList.Add(new WordModel() { StringOriginal = "Test" });
            var list = new List<Label>();
            list.Add(new Label(){Content = "test1"});
            list.Add(new Label() { Content = "test2" });
            //list.Add(new ActiveLabel() { });
            icTest.ItemsSource = list;
        }

        private void RichTextBox_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {

        }

        private void RichTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ActiveLabel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void ActiveLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            ActiveLabel label = (ActiveLabel)sender;
            label.BorderThickness = new Thickness(0);
        }

        private void ActiveLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            ActiveLabel label = (ActiveLabel)sender;
            label.BorderThickness = new Thickness(5);
        }

        private void rtb_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wpOriginal.Children.Add(new ActiveLabel() {ContentText = "test1_"+DateTime.Now.ToString() });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString() });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString() });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString() });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString(), BorderThickness = new Thickness(5), BorderBrush = Brushes.Black });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString() });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString() });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString() });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString() });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString() });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString() });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString() });
            wpOriginal.Children.Add(new ActiveLabel() { ContentText = "test1_" + DateTime.Now.ToString() });
            /*Paragraph par = new Paragraph();
            par.Inlines.Add("test_" + DateTime.Now.ToString());
            Paragraph par1 = new Paragraph();
            par1.Inlines.Add("test1_" + DateTime.Now.ToString());
            //rtb.Document.Blocks.Add(par);
            List<Paragraph> listPar = new List<Paragraph>();
            listPar.Add(par);
            listPar.Add(par1);
            rtb.Document.Blocks.AddRange(listPar);
            //rtb.AppendText("test_" + DateTime.Now.ToString());*/
        }

    }
}
