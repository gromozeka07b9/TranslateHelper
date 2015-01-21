using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TranslateCustomControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ActiveLabel : UserControl
    {

        public static DependencyProperty ContentTextProperty;
        public string ContentText
        {
            get
            {
                return (string)GetValue(ContentTextProperty);
            }
            set
            {
                SetValue(ContentTextProperty, value);
            }
        }
        static ActiveLabel()
        {
            //InitializeComponent();
            ContentTextProperty = DependencyProperty.Register("ContentText", typeof(string), typeof(ActiveLabel), new FrameworkPropertyMetadata("default value", new PropertyChangedCallback(OnContentTextChanged)));
            
        }

        private static void OnContentTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ActiveLabel label = (ActiveLabel)sender;
            if (e.Property == ContentTextProperty)
            {
                label.Content = (string)e.NewValue;
                label.BorderBrush = Brushes.Black;
                label.BorderThickness = new Thickness(5);
            }     
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            ActiveLabel label = (ActiveLabel)sender;
            label.BorderBrush = Brushes.Black;
            label.BorderThickness = new Thickness(5);
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}

