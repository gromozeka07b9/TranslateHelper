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
            //icTest.ItemsSource = StringControlList;
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
    }
}
