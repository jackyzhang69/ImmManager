using System;
using System.Windows.Forms;

namespace ImmManager
{
    public static class Enviorment
    {
        public static BCPNP_Skill_Worker f1 = new BCPNP_Skill_Worker();
        

    }
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        public static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Enviorment.f1);
           
        }
    }
}
