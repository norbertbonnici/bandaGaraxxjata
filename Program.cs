using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BandaGaraxxjata
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MusicKeyboard());
            //Code Freezed 14/1/2012 vr 1.3.2
        }
    }
}
