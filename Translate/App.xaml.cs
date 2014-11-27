using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Translate.ViewModels;
using Translate.Views;

namespace Translate
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mw = new Views.MainWindow()
            {
                DataContext = new MainWindowViewModel()
            };
            mw.Show();

        }
    }
}
