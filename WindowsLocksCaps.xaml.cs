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
using System.Windows.Shapes;
using OpenHardwareMonitor.Hardware;
using System.Timers;
using IniParser;
using IniParser.Model;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace MonitorTemperatura
{
    public partial class WindowsLocksCaps : Window
    {
        public WindowsLocksCaps()
        {
            UpdateText();
            ExTransparent();
            InitializeComponent();
        }
        public void ExTransparent() {
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
