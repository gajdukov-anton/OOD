using ChartDrawer.Controller;
using ChartDrawer.Util;
using System;
using System.Windows.Forms;

namespace ChartDrawer.View.MainMenu.EventHandlers
{
    public class AmplitudeEventHandler
    {
        private TextBox _amplitudeTextBox;
        private ErrorProvider _amplitudeErrorProvider;
        private IMainMenuController _mainMenuController;
        private ListBox _harmonicList;

        public AmplitudeEventHandler( IMainMenuController mainMenuController, ListBox harmonicList, ErrorProvider errorProvider ,TextBox amplitudeTextBox )
        {
            _mainMenuController = mainMenuController;
            _amplitudeTextBox = amplitudeTextBox;
            _amplitudeErrorProvider = errorProvider;
            _harmonicList = harmonicList;
            _amplitudeTextBox.TextChanged += new EventHandler( AmplitudeTextBox_TextChanged );
        }

        private void AmplitudeTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !Validator.CanProcessTextBoxStringValue( _amplitudeTextBox, _harmonicList.SelectedIndex ) )
            {
                return;
            }
            var amplitudeValue = Validator.ProcessTextBoxStringValue( _amplitudeTextBox.Text );
            if ( amplitudeValue != null )
            {
                _amplitudeErrorProvider.Clear();
                _mainMenuController.SetNewAmplitude( _harmonicList.SelectedIndex, amplitudeValue.Value );
            }
            else
            {
                _amplitudeErrorProvider.SetError( _amplitudeTextBox, Constants.IMPOSSIBLE_TO_USE_LETTERS );
            }
        }
    }
}
