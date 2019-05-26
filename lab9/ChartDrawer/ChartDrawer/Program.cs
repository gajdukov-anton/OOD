using System;
using System.Windows.Forms;
using ChartDrawer.Model;
using ChartDrawer.View;

namespace ChartDrawer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            var harmonicContainer = new HarmonicContainer();
            var mainMenuController = new Controller.MainMenuController( harmonicContainer );            
            Application.Run( mainMenuController.MainMenuView );
        }
    }
}
