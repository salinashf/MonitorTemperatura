using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
          
        }
    }
}
