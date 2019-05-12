using System;
using System.Windows.Forms;
using ChartDrawer.Model;

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
            FillHarmonicContainer( harmonicContainer );
            var mainMenuController = new Controller.MainMenuController( harmonicContainer );
            var mainMenu = new View.MainMenu( harmonicContainer, mainMenuController );
            harmonicContainer.RegisterObserver( mainMenu );

            Application.Run( mainMenu );
        }

        private static void FillHarmonicContainer( IHarmonicContainer harmonicContainer )
        {
            harmonicContainer.AddHarmonic( new Harmonic( 10, 12, 14, HarmonicKind.Cos ) );
            harmonicContainer.AddHarmonic( new Harmonic( 100, 120, 140, HarmonicKind.Sin ) );
            harmonicContainer.AddHarmonic( new Harmonic( 1000, 1200, 1400, HarmonicKind.Cos ) );
        }
    }
}
