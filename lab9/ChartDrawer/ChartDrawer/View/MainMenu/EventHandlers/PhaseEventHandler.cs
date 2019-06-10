using ChartDrawer.Controller;
using ChartDrawer.Util;
using System;
using System.Windows.Forms;

namespace ChartDrawer.View.MainMenu.EventHandlers
{
    public class PhaseEventHandler
    {
        private TextBox _phaseTextBox;
        private ErrorProvider _phaseErrorProvider;
        private IMainMenuController _mainMenuController;
        private ListBox _harmonicList;

        public PhaseEventHandler( IMainMenuController mainMenuController, ListBox harmonicList, ErrorProvider errorProvider, TextBox phaseyTextBox )
        {
            _mainMenuController = mainMenuController;
            _phaseTextBox =phaseyTextBox;
            _phaseErrorProvider = errorProvider;
            _harmonicList = harmonicList;
            _phaseTextBox.TextChanged += new EventHandler( PhaseTextBox_TextChanged );
        }

        private void PhaseTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !Validator.CanProcessTextBoxStringValue( _phaseTextBox, _harmonicList.SelectedIndex ) )
            {
                return;
            }
            var phaseValue = Validator.ProcessTextBoxStringValue( _phaseTextBox.Text );
            if ( phaseValue != null )
            {
                _phaseErrorProvider.Clear();
                _mainMenuController.SetNewPhase( _harmonicList.SelectedIndex, phaseValue.Value );
            }
            else
            {
                _phaseErrorProvider.SetError( _phaseTextBox, Constants.IMPOSSIBLE_TO_USE_LETTERS );
            }
        }

    }
}
