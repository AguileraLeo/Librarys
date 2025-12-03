using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlayerUI.Presentacion;

namespace PlayerUI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// AHORA INICIA EN EL LOGIN en lugar de ir directo al menú principal
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // CAMBIO IMPORTANTE: Ahora inicia en Login, no en frmMain
            Application.Run(new frmLogin());
        }
    }
}
