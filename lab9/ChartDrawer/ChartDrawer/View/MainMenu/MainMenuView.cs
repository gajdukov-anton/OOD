using ChartDrawer.Controller;
using ChartDrawer.Model;
using ChartDrawer.Util;
using ChartDrawer.View.MainMenu.EventHandlers;
using System;
using System.Windows.Forms;

namespace ChartDrawer.View.MainMenu
{
    public partial class MainMenuView : Form, IHarmonicObserver, IHarmonicContainerObserver
    {
        private IHarmonicContainerPresentation _harmonicContainer;
        private IMainMenuController _mainMenuController;
        private HarmonicContainerVizualizer _harmonicContainerVizualization;
        private AmplitudeEventHandler _amplitudeEventHandler;
        private FrequencyEventHandler _frequencyEventHandler;
        private PhaseEventHandler _phaseEventHandler;
        private HarmonicKindEventHandler _harmonicKindEventHandler;

        public MainMenuView( IHarmonicContainerPresentation harmonicContainer, IMainMenuController mainMenuController )
        {
            InitializeComponent();
            _mainMenuController = mainMenuController;
            _harmonicContainer = harmonicContainer;
            _harmonicContainerVizualization = new HarmonicContainerVizualizer( _harmonicContainer, tabPage1, chartTableView );
            _harmonicContainer.AddObserver( _harmonicContainerVizualization );
            InitializeEventHandlers();
        }

        public void AddedNewHarmonic( int index )
        {
            harmonicList.Items.Add( Convertor.ConvertHarmonicToStr(_harmonicContainer.GetAllPresentation() [ index ]) );
        }

        public void RemovedHarmonic( int index )
        {
            harmonicList.Items.RemoveAt( index );
            ResetHarmonicPropertiesView();
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
            harmonicList.SelectedIndex = -1;
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

        private void HarmonicList_SelectedIndexClicked( object sender, EventArgs e )
        {
            if ( harmonicList.SelectedIndex >= 0 )
            {
                EnableInputMethods( true );
                var harmonicPresentation = _harmonicContainer.GetAllPresentation() [ harmonicList.SelectedIndex ];
                SetHarmonicPropertiesToView( harmonicPresentation );
            }
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
            EnableInputMethods( false );
        }

        private void HarmonicList_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( harmonicList.Items.Count == 0 )
            {
                EnableInputMethods( false );
            }
        }

        private void InitializeEventHandlers()
        {
            _amplitudeEventHandler = new AmplitudeEventHandler( _mainMenuController, harmonicList, amplitudeErrorProvider, amplitudeTextBox );
            _frequencyEventHandler = new FrequencyEventHandler( _mainMenuController, harmonicList, frequencyErrorProvider, frequencyTextBox );
            _phaseEventHandler = new PhaseEventHandler( _mainMenuController, harmonicList, phaseErrorProvider, phaseTextBox );
            _harmonicKindEventHandler = new HarmonicKindEventHandler( _mainMenuController, harmonicList, sinRadioButton, cosRadioButton );
        }

        private void amplitudeTextBox_TextChanged( object sender, EventArgs e )
        {

        }
    }
}