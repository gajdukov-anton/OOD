using ChartDrawer.Controller;
using ChartDrawer.Model;
using ChartDrawer.Util;
using System;
using System.Windows.Forms;

namespace ChartDrawer.View
{
    public partial class MainMenuView : Form, IHarmonicObserver, IHarmonicContainerObserver
    {
        private IHarmonicContainerPresentation _harmonicContainer;
        private IMainMenuController _mainMenuController;
        private HarmonicContainerVizualization _harmonicContainerVizualization;

        public MainMenuView( IHarmonicContainerPresentation harmonicContainer, IMainMenuController mainMenuController )
        {
            InitializeComponent();
            _mainMenuController = mainMenuController;
            _harmonicContainer = harmonicContainer;
            _harmonicContainerVizualization = new HarmonicContainerVizualization( _harmonicContainer, tabPage1, chartTableView );
        }

        public void AddedNewHarmonic( int index )
        {
            harmonicList.Items.Add( Convertor.ConvertHarmonicToStr(_harmonicContainer.GetAllPresentation() [ index ]) );
            _harmonicContainerVizualization.AddNewHarmonic( index );
        }

        public void RemovedHarmonic( int index )
        {
            harmonicList.Items.RemoveAt( index );
            ResetHarmonicPropertiesView();
            _harmonicContainerVizualization.Update();
        }

        public void HarmonicPropertiesChanged()
        {
            _harmonicContainerVizualization.Update();
            if ( harmonicList.SelectedIndex != -1 )
            {
                UpdateStringPresentation( harmonicList.SelectedIndex );
            }
            else
            {
                ResetHarmonicPropertiesView();
            }
        }

        private void UpdateStringPresentation( int harmonicIndex )
        {
            harmonicList.Items [ harmonicIndex ] = Convertor.ConvertHarmonicToStr( _harmonicContainer.GetAllPresentation() [ harmonicIndex ] );
        }

        private void SetHarmonicPropertiesToView( IHarmonicPresentation harmonic )
        {
            amplitudeTextBox.Text = harmonic.GetAmplitude().ToString();
            frequencyTextBox.Text = harmonic.GetFrequency().ToString();
            phaseTextBox.Text = harmonic.GetPhase().ToString();
            sinRadioButton.Checked = harmonic.GetHarmonicKind() == HarmonicKind.Sin ? true : false;
            cosRadioButton.Checked = harmonic.GetHarmonicKind() == HarmonicKind.Cos ? true : false;
        }

        private void ResetHarmonicPropertiesView()
        {
            amplitudeTextBox.Text = "";
            frequencyTextBox.Text = "";
            phaseTextBox.Text = "";
            sinRadioButton.Checked = false;
            cosRadioButton.Checked = false;
            EnableInputMethods( false );
        }

        private void EnableInputMethods( bool value )
        {
            amplitudeTextBox.Enabled = value;
            frequencyTextBox.Enabled = value;
            phaseTextBox.Enabled = value;
            sinRadioButton.Enabled = value;
            cosRadioButton.Enabled = value;
            deleteHarmonicButton.Enabled = value;
        }

        private void SinRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( !sinRadioButton.Focused || harmonicList.SelectedIndex == -1 )
            {
                return;
            }
            _mainMenuController.SetNewHarmonicKind( harmonicList.SelectedIndex, HarmonicKind.Sin );
        }

        private void CosRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( !cosRadioButton.Focused || harmonicList.SelectedIndex == -1 )
            {
                return;
            }
            _mainMenuController.SetNewHarmonicKind( harmonicList.SelectedIndex, HarmonicKind.Cos );
        }

        private void HarmonicList_SelectedIndexClicked( object sender, EventArgs e )
        {
            if ( harmonicList.SelectedIndex >= 0 )
            {
                EnableInputMethods( true );
                var harmonicPresentation = _harmonicContainer.GetAllPresentation() [ harmonicList.SelectedIndex ];
                SetHarmonicPropertiesToView( harmonicPresentation );
            }
        }

        private void AmplitudeTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !CanProcessTextBoxStringValue( amplitudeTextBox ) )
            {
                return;
            }
            var amplitudeValue = Validator.ProcessTextBoxStringValue( amplitudeTextBox.Text );
            if ( amplitudeValue != null )
            {
                amplitudeErrorProvider.Clear();
                _mainMenuController.SetNewAmplitude( harmonicList.SelectedIndex, amplitudeValue.Value );
            }
            else
            {
                amplitudeErrorProvider.SetError( amplitudeTextBox, Constants.IMPOSSIBLE_TO_USE_LETTERS );
            }
        }

        private void FrequencyTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !CanProcessTextBoxStringValue( frequencyTextBox ) )
            {
                return;
            }
            var frequencyValue = Validator.ProcessTextBoxStringValue( frequencyTextBox.Text );
            if ( frequencyValue != null )
            {
                frequencyErrorProvider.Clear();
                _mainMenuController.SetNewFrequency( harmonicList.SelectedIndex, frequencyValue.Value );
            }
            else
            {
                frequencyErrorProvider.SetError( frequencyTextBox, Constants.IMPOSSIBLE_TO_USE_LETTERS );
            }
        }

        private void PhaseTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !CanProcessTextBoxStringValue( phaseTextBox ) )
            {
                return;
            }
            var phaseValue = Validator.ProcessTextBoxStringValue( phaseTextBox.Text );
            if ( phaseValue != null )
            {
                phaseErrorProvider.Clear();
                _mainMenuController.SetNewPhase( harmonicList.SelectedIndex, phaseValue.Value );
            }
            else
            {
                phaseErrorProvider.SetError( phaseTextBox, Constants.IMPOSSIBLE_TO_USE_LETTERS );
            }
        }

        private bool CanProcessTextBoxStringValue( TextBox textBox )
        {
            return textBox.Focused && !string.IsNullOrEmpty( textBox.Text ) && harmonicList.SelectedIndex != -1;
        }

        private void DeleteHarmonicButton_Click( object sender, EventArgs e )
        {
            if ( harmonicList.SelectedIndex != -1 )
            {
                _mainMenuController.RemoveHarmonic( harmonicList.SelectedIndex );
            }
        }

        private void AddNewHarmonicButton_Click( object sender, EventArgs e )
        {
            _mainMenuController.StartAddingNewHarmonic();
        }

        private void MainMenu_Load( object sender, EventArgs e )
        {
            _harmonicContainerVizualization.Update();
            EnableInputMethods( false );
        }

        private void HarmonicList_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( harmonicList.Items.Count == 0 )
            {
                EnableInputMethods( false );
            }
        }
    }
}