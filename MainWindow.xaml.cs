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
        public void DragWindow(object sender, MouseButtonEventArgs args)
        {
            this.DragMove();
        }

        public void ExTransparent() {

            this.Opacity = 0.6;
            this.IsHitTestVisible = false;
            var hwnd = new WindowInteropHelper(this).Handle;
            WindowsServices.SetWindowExTransparent2(hwnd);
        }


        public String gpuvalue;
        public String cpuvalue;
        public void UpdateText()
        {

            Computer computer = new Computer() { CPUEnabled = true, GPUEnabled = true };
            computer.Open();

            System.Timers.Timer timer = new System.Timers.Timer() { Enabled = true, Interval = 1000 };
            timer.Elapsed += delegate (object sender, ElapsedEventArgs e)
            {



                foreach (IHardware hardware in computer.Hardware)
                {
                    hardware.Update();

                    foreach (ISensor sensor in hardware.Sensors)
                    {

                        if (sensor.SensorType == SensorType.Temperature)
                        {



                            if (sensor.Name == "GPU Core")
                            {
                                gpuvalue = sensor.Value.ToString();

                            }
                            if (sensor.Name == "CPU Package")
                            {
                                cpuvalue = Convert.ToInt32(sensor.Value).ToString();
                            }

                            Dispatcher.Invoke((Action)delegate () { set_gpu_value(); });
                        }

                    }
                    Console.WriteLine();
                }
            };

        }
        private void set_gpu_value()
        {
            if (Convert.ToInt32(cpuvalue) > 50)
            {
                circle_value.EndAngle = (Convert.ToInt32(cpuvalue) - 50) * 3.6;
            }
            else
            {
                circle_value.EndAngle = (Convert.ToInt32(cpuvalue)) * 3.6 - 180;
            }
            cpu_label.Content = cpuvalue;
            if (Convert.ToInt32(gpuvalue) > 50)
            {
                circle_value_Copy.EndAngle = (Convert.ToInt32(gpuvalue) - 50) * 3.6;
            }
            else
            {
                circle_value_Copy.EndAngle = (Convert.ToInt32(gpuvalue)) * 3.6 - 180;
            }
            gpu_label.Content = gpuvalue;

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
