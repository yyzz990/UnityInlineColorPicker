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
using Microsoft.VisualStudio.Text;
using System.Diagnostics;
using System.Windows.Threading;

namespace InlineColorPicker {
    /// <summary>
    /// Interaction logic for ColorAdorner.xaml
    /// </summary>
    public partial class ColorAdorner : UserControl {
        ColorTag _tag = null;
        public ColorAdorner(ColorTag tag) {
            InitializeComponent();
            Update(tag);
        }
        
        private ColorInfo _currentColor = new ColorInfo() { Color = Colors.Red, WasSpecifiedWithAlpha = true };
        
        /// <summary>
        /// 
        /// </summary>
        internal ColorInfo ColorInfo {
            get { return _currentColor; }
            set {
                _currentColor = value;
                if (_currentColor.Color == null) {
                    rectColor.Fill = null;
                    line1.Visibility = Visibility.Collapsed;
                    line2.Visibility = Visibility.Collapsed;
                }
                else 
                {
                    rectColor.Fill = new SolidColorBrush(_currentColor.Color.Value);
                    line1.Visibility = Visibility.Visible;
                    line2.Visibility = Visibility.Visible;
                }
            }
        }

        public void Update(ColorTag tag) {
            _tag = tag;
            this.ColorInfo = _tag.ColorInfo;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e) {
            
        }


    }
}
