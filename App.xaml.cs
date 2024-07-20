using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MonitorTemperatura
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            bool isCapsLockOn = Keyboard.IsKeyToggled(Key.CapsLock);
            if (isCapsLockOn)
            {
                this.StartupUri = new Uri("WindowsLocksCaps.xaml", UriKind.Relative);
            }
            else
            {
                this.StartupUri = new Uri("WindowsUnLocksCaps.xaml", UriKind.Relative);
            }
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Detiene el temporizador y cierra la aplicación
            DispatcherTimer timer = sender as DispatcherTimer;
            if (timer != null)
            {
                timer.Stop();
            }
            Application.Current.Shutdown();
        }
    }
}
