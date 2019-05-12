using ChartDrawer.Controller;
using ChartDrawer.Model;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartDrawer.View
{
    public partial class MainMenu : Form, IObserver
    {
        private const string CHART_AREA_NAME = "ChartGraphic";

        private IHarmonicContainerPresentation _harmonicContainer;
        private IMainMenuController _mainMenuController;
        private Chart _chart;

        public MainMenu( IHarmonicContainerPresentation harmonicContainer, IMainMenuController mainMenuController )
        {
            InitializeComponent();
            _mainMenuController = mainMenuController;
            _harmonicContainer = harmonicContainer;
            harmonicList.Items.AddRange( _harmonicContainer.GetAllPresentation() );
            _chart = CreateChart();
        }

        public void Update( HarmonicsChangesDto harmonicsChangesDto )
        {
            RemoveHarmonicFromListIfEnabled( harmonicsChangesDto );
            UpdateHarmonicInListIfEnabled( harmonicsChangesDto );
            AddNewHarmonicToListIfEnabled( harmonicsChangesDto );
        }

        private void Harmonics_Paint( object sender, PaintEventArgs e )
        {

        }

        private void GroupBox1_Enter( object sender, EventArgs e )
        {

        }

        private void SinRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( !sinRadioButton.Focused )
            {
                return;
            }
            _mainMenuController.SetNewHarmonicKind( harmonicList.SelectedIndex, HarmonicKind.Sin );
        }

        private void CosRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( !cosRadioButton.Focused )
            {
                return;
            }
            _mainMenuController.SetNewHarmonicKind( harmonicList.SelectedIndex, HarmonicKind.Cos );
        }

        private void MainMenu_Load( object sender, EventArgs e )
        {

        }

        private void AmplitudeLabel_Click( object sender, EventArgs e )
        {
        }

        private void HarmonicList_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( harmonicList.SelectedIndex >= 0 )
            {
                var harmonicPresentation = _harmonicContainer.GetHarmonicPresentation( harmonicList.SelectedIndex );
                SetHarmonicPropertiesToView( harmonicPresentation );
                DrawChart( harmonicPresentation );
            }
        }

        private void Harmonics_Enter( object sender, EventArgs e )
        {

        }

        private void SetHarmonicPropertiesToView( IHarmonicPresentation harmonic )
        {
            amplitudeTextBox.Text = harmonic.GetAmplitude().ToString();
            frequencyTextBox.Text = harmonic.GetFrequency().ToString();
            phaseTextBox.Text = harmonic.GetPhase().ToString();
            sinRadioButton.Checked = harmonic.GetHarmonicKind() == HarmonicKind.Sin ? true : false;
            cosRadioButton.Checked = harmonic.GetHarmonicKind() == HarmonicKind.Cos ? true : false;
        }

        private void RemoveHarmonicFromListIfEnabled( HarmonicsChangesDto harmonicsChangesDto )
        {
            if ( harmonicsChangesDto.DeletedHarmonicIndex.HasValue )
            {
                harmonicList.SetSelected( ( int ) harmonicsChangesDto.DeletedHarmonicIndex, false );
                harmonicList.Items.RemoveAt( ( int ) harmonicsChangesDto.DeletedHarmonicIndex );
                ResetHarmonicPropertiesView();
            }
        }

        private void AddNewHarmonicToListIfEnabled( HarmonicsChangesDto harmonicsChangesDto )
        {
            if ( harmonicsChangesDto.AddedHarmonicIndex.HasValue )
            {
                var newHarmonic = _harmonicContainer.GetHarmonicPresentation( ( int ) harmonicsChangesDto.AddedHarmonicIndex );
                harmonicList.Items.Add( newHarmonic );
            }
        }

        private void UpdateHarmonicInListIfEnabled( HarmonicsChangesDto harmonicsChangesDto )
        {
            if ( harmonicsChangesDto.ChangedHarmonicIndex.HasValue )
            {
                var changedHarmonic = _harmonicContainer.GetHarmonicPresentation( ( int ) harmonicsChangesDto.ChangedHarmonicIndex );
                harmonicList.Items.RemoveAt( ( int ) harmonicsChangesDto.ChangedHarmonicIndex );
                harmonicList.Items.Insert( ( int ) harmonicsChangesDto.ChangedHarmonicIndex, changedHarmonic );
                harmonicList.SelectedIndex = harmonicList.SelectedIndex == -1 ? ( int ) harmonicsChangesDto.ChangedHarmonicIndex : harmonicList.SelectedIndex;
                DrawChart( changedHarmonic );
            }
        }

        private void ResetHarmonicPropertiesView()
        {
            amplitudeTextBox.Text = "";
            frequencyTextBox.Text = "";
            phaseTextBox.Text = "";
            sinRadioButton.Checked = false;
            cosRadioButton.Checked = false;
        }

        private void AmplitudeTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !amplitudeTextBox.Focused )
            {
                return;
            }
            _mainMenuController.SetNewAmplitude( harmonicList.SelectedIndex, Convert.ToDouble( amplitudeTextBox.Text ) );
        }

        private void FrequencyTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !frequencyTextBox.Focused )
            {
                return;
            }
            _mainMenuController.SetNewFrequency( harmonicList.SelectedIndex, Convert.ToDouble( frequencyTextBox.Text ) );
        }

        private void PhaseTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !phaseTextBox.Focused )
            {
                return;
            }
            _mainMenuController.SetNewPhase( harmonicList.SelectedIndex, Convert.ToDouble( phaseTextBox.Text ) );
        }

        private void DeleteHarmonicButton_Click( object sender, EventArgs e )
        {
            _mainMenuController.RemoveHarmonic( harmonicList.SelectedIndex );
        }

        private void AddNewHarmonicButton_Click( object sender, EventArgs e )
        {
            AddingNewHarmonics addingNewHarmonic = new AddingNewHarmonics( _mainMenuController.GetAddingNewHarmonicController() );
            addingNewHarmonic.Show();
        }

        private void DrawChart( IHarmonicPresentation harmonicPresentation )
        {
            _chart.Series.Clear();
            _chart.ChartAreas.Clear();
            _chart.ChartAreas.Add( new ChartArea( CHART_AREA_NAME ) );

            //Создаем и настраиваем набор точек для рисования графика, в том
            //не забыв указать имя области на которой хотим отобразить этот
            //набор точек.
            Series mySeriesOfPoint = new Series
            {
                ChartType = SeriesChartType.Line,
                ChartArea = CHART_AREA_NAME
            };
            for ( double x = 0; x <= 4.5; x += 0.5 )
            {
                mySeriesOfPoint.Points.AddXY( x, CreateYValue( x, harmonicPresentation ) );
            }
            //Добавляем созданный набор точек в Chart
            _chart.Series.Add( mySeriesOfPoint );
        }

        private double CreateYValue( double xValue, IHarmonicPresentation harmonicPresentation )
        {
            var amplitude = harmonicPresentation.GetAmplitude();
            var frequency = harmonicPresentation.GetFrequency();
            var phase = harmonicPresentation.GetPhase();
            return harmonicPresentation.GetHarmonicKind() == HarmonicKind.Sin
                ? amplitude * Math.Sin( frequency * xValue + phase )
                : amplitude * Math.Cos( frequency * xValue + phase );
        }

        private Chart CreateChart()
        {
            return new Chart
            {
                Parent = tabPage1,
                Dock = DockStyle.Fill
            };
        }
    }
}