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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MonitorTemperatura
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class WindowsUnLocksCaps : Window
    {
        public WindowsUnLocksCaps()
        {
            UpdateText();
            ExTransparent();
            InitializeComponent();
        }
        public void ExTransparent()
        {
            this.Opacity = 0.6;
            this.IsHitTestVisible = false;
            var hwnd = new WindowInteropHelper(this).Handle;
            WindowsServices.SetWindowExTransparent2(hwnd);
        }
        public void UpdateText()
        {

        }
    }
}
