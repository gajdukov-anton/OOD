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
         //   FillHarmonicContainer( harmonicContainer, mainMenuController.MainMenu );
            
            Application.Run( mainMenuController.MainMenu );
        }

        private static void FillHarmonicContainer( IHarmonicContainer harmonicContainer, IHarmonicObserver harmonicObserver )
        {
            var harmonicOne = new Harmonic( 4.38, 2.25, 1.5, HarmonicKind.Sin );
            var harmonicTwo = new Harmonic( 1, 1, 5, HarmonicKind.Cos );
            var harmonicThree = new Harmonic( 3, -3, 0.3, HarmonicKind.Sin );

            harmonicOne.SetViewObserver( harmonicObserver );
            harmonicTwo.SetViewObserver( harmonicObserver );
            harmonicThree.SetViewObserver( harmonicObserver );

            harmonicContainer.AddHarmonic( harmonicOne );
            harmonicContainer.AddHarmonic( harmonicTwo );
            harmonicContainer.AddHarmonic( harmonicThree );
        }
    }
}
