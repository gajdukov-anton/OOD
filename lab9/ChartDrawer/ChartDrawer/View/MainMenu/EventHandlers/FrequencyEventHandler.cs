using ChartDrawer.Controller;
using ChartDrawer.Util;
using System;
using System.Windows.Forms;

namespace ChartDrawer.View.MainMenu.EventHandlers
{
    public class FrequencyEventHandler
    {
        private TextBox _frequencyTextBox;
        private ErrorProvider _frequencyErrorProvider;
        private IMainMenuController _mainMenuController;
        private ListBox _harmonicList;

        public FrequencyEventHandler( IMainMenuController mainMenuController, ListBox harmonicList, ErrorProvider errorProvider, TextBox frequencyTextBox )
        {
            _mainMenuController = mainMenuController;
            _frequencyTextBox = frequencyTextBox;
            _frequencyErrorProvider = errorProvider;
            _harmonicList = harmonicList;
            _frequencyTextBox.TextChanged += new EventHandler( FrequencyTextBox_TextChanged );
        }

        private void FrequencyTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !CanProcessTextBoxStringValue( _frequencyTextBox ) )
            {
                return;
            }
            var frequencyValue = Validator.ProcessTextBoxStringValue( _frequencyTextBox.Text );
            if ( frequencyValue != null )
            {
                _frequencyErrorProvider.Clear();
                _mainMenuController.SetNewFrequency( _harmonicList.SelectedIndex, frequencyValue.Value );
            }
            else
            {
                _frequencyErrorProvider.SetError( _frequencyTextBox, Constants.IMPOSSIBLE_TO_USE_LETTERS );
            }
        }

        private bool CanProcessTextBoxStringValue( TextBox textBox )
        {
            return textBox.Focused && !string.IsNullOrEmpty( textBox.Text ) && _harmonicList.SelectedIndex != -1;
        }
    }
}
