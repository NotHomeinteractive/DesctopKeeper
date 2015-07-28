using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Configuration;

namespace DiskKiperForm
{
   

    static class Program
    {
        [STAThread]
        static void Main()
        {
            string PatchProfile = Environment.GetEnvironmentVariable("USERPROFILE");


          //  Application.EnableVisualStyles();
          //  Application.SetCompatibleTextRenderingDefault(false);
          //  Application.Run(new Form1());
        }
    }
}
