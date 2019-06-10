using ChartDrawer.Controller;
using ChartDrawer.Model;
using ChartDrawer.Util;
using System;
using System.Windows.Forms;

namespace ChartDrawer.View.MainMenu.EventHandlers
{
    public class HarmonicKindEventHandler
    {
        private RadioButton _sinRadioButton;
        private RadioButton _cosRadioButton;
        private IMainMenuController _mainMenuController;
        private ListBox _harmonicList;

        public HarmonicKindEventHandler( IMainMenuController mainMenuController, ListBox harmonicList, RadioButton sinRadioButton, RadioButton cosRadioButton )
        {
            _mainMenuController = mainMenuController;
            _sinRadioButton = sinRadioButton;
            _cosRadioButton = cosRadioButton;
            _harmonicList = harmonicList;
            _sinRadioButton.CheckedChanged += new EventHandler( SinRadioButton_CheckedChanged );
            _cosRadioButton.CheckedChanged += new EventHandler( CosRadioButton_CheckedChanged );
        }

        private void SinRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( !_sinRadioButton.Focused || _harmonicList.SelectedIndex == -1 )
            {
                return;
            }
            _mainMenuController.SetNewHarmonicKind( _harmonicList.SelectedIndex, HarmonicKind.Sin );
        }

        private void CosRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( !_cosRadioButton.Focused || _harmonicList.SelectedIndex == -1 )
            {
                return;
            }
            _mainMenuController.SetNewHarmonicKind( _harmonicList.SelectedIndex, HarmonicKind.Cos );
        }
    }
}
