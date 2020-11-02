using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartManager
{
    class Program
    {
        static void Main(string[] args)
        {

            Microsoft.Win32.RegistryKey rkApp = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            rkApp.SetValue("Test", @"C:\Users\Marco\source\repos\cymarce\volta\Comunicatore\bin\Debug\comunicatore.exe");
            //NB SetValue sovrascrive eventuali valori già presenti per la medesima variabile




        }
    }
}
