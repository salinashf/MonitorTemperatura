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
    public partial class MainWindow : Window
    {
        public MainWindow()
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
        public static class WindowsServices
        {
            const int WS_EX_TRANSPARENT = 0x00000020;
            const int GWL_EXSTYLE = (-20);
            [DllImport("user32.dll")]
            static extern int GetWindowLong(IntPtr hwnd, int index);
            [DllImport("user32.dll")]
            static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);
            public static void SetWindowExTransparent(IntPtr hwnd)     
            {
                var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
                SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
            }
            public static void SetWindowExTransparent2(IntPtr hwnd)   
            {
                var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
                SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle & ~WS_EX_TRANSPARENT);
            }
        }


    }
}
