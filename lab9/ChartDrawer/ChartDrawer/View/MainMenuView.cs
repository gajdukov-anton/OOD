using ChartDrawer.Controller;
using ChartDrawer.Model;
using ChartDrawer.Util;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartDrawer.View
{
    public partial class MainMenuView : Form, IHarmonicObserver, IHarmonicContainerObserver
    {
        private const double COORDINATE_STEP = 0.5;
        private const int COORDINATE_AMOUNT = 20;

        private double [,] _harmonicChartCoordinate;
        private IHarmonicContainerPresentation _harmonicContainer;
        private IMainMenuController _mainMenuController;
        private Chart _chart;
        private HarmonicContainerVizualization _harmonicContainerVizualization;

        public MainMenuView( IHarmonicContainerPresentation harmonicContainer, IMainMenuController mainMenuController )
        {
            InitializeComponent();
         //   FillXCoordinate();
            _mainMenuController = mainMenuController;
            _harmonicContainer = harmonicContainer;
            harmonicList.Items.AddRange( _harmonicContainer.GetAllPresentation() );
            _harmonicContainerVizualization = new HarmonicContainerVizualization( _harmonicContainer, tabPage1, chartTableView );
          //  _chart = CreateChart();
        }

        public void UpdateSumHarmonicVizualization()
        {
            _harmonicContainerVizualization.UpdateVizualization();
        }

        public void AddedNewHarmonic( int index )
        {
            harmonicList.Items.Add( _harmonicContainer.GetAllPresentation() [ index ] );
            _harmonicContainerVizualization.UpdateVizualization();

            /*if ( harmonicChangesListData.AddedHarmonicIndex.HasValue )
            {
                harmonicList.Items.Add( _harmonicContainer.GetAllPresentation()[ harmonicChangesListData.AddedHarmonicIndex.Value ] );
            }
            else if ( harmonicChangesListData.RemovedHarmonicIndex.HasValue )
            {
                harmonicList.Items.RemoveAt( harmonicChangesListData.RemovedHarmonicIndex.Value );
                ResetHarmonicPropertiesView();
            }*/
        }

        public void RemovedHarmonic(int index)
        {
            harmonicList.Items.RemoveAt( index );
            ResetHarmonicPropertiesView();
            _harmonicContainerVizualization.UpdateVizualization();
        }

        public void HarmonicPropertyChanged()
        {
            _harmonicContainerVizualization.UpdateVizualization();
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
            harmonicList.Items [ harmonicIndex ] = _harmonicContainer.GetAllPresentation() [ harmonicIndex ].ToString();
        }

        /*  private void UpdateChartView()
          {
              UpdateHarmonicChartYCoordinate();
              DrawChart();
              FillTable();
          }

          private void UpdateHarmonicChartYCoordinate()
          {
              for ( int i = 0; i < COORDINATE_AMOUNT; i++ )
              {
                  _harmonicChartCoordinate [ i, 1 ] = Math.Round( 0.0, 5 );
              }
              var harmonics = _harmonicContainer.GetAllPresentation();
              foreach ( var harmonic in harmonics )
              {
                  for ( int i = 0; i < COORDINATE_AMOUNT; i++ )
                  {
                      _harmonicChartCoordinate [ i, 1 ] += Math.Round( GetYValue( _harmonicChartCoordinate[i, 0], harmonic ), 5 );
                  }
              }
          }

          private void FillXCoordinate()
          {
              _harmonicChartCoordinate = new double [ COORDINATE_AMOUNT, 2 ];
              double xValue = 0;
              for ( int i = 0; i < COORDINATE_AMOUNT; i++ )
              {
                  _harmonicChartCoordinate [ i, 0 ] = Math.Round( xValue, 5 );
                  xValue += COORDINATE_STEP;
              }
          }

          private double GetYValue( double xValue, IHarmonicPresentation harmonicPresentation )
          {
              var amplitude = harmonicPresentation.GetAmplitude();
              var frequency = harmonicPresentation.GetFrequency();
              var phase = harmonicPresentation.GetPhase();
              return harmonicPresentation.GetHarmonicKind() == HarmonicKind.Sin
                  ? amplitude * Math.Sin( frequency * xValue + phase )
                  : amplitude * Math.Cos( frequency * xValue + phase );
          }

          private void DrawChart()
          {
              _chart.Series.Clear();
              _chart.ChartAreas.Clear();
              _chart.ChartAreas.Add( new ChartArea( Constants.CHART_AREA_NAME ) );
              _chart.ChartAreas [ 0 ].AxisX.Minimum = 0;
              _chart.ChartAreas [ 0 ].AxisX.Maximum = COORDINATE_STEP * 12;
              Series mySeriesOfPoint = new Series
              {
                  ChartType = SeriesChartType.Spline,
                  ChartArea = Constants.CHART_AREA_NAME
              };
              int rows = _harmonicChartCoordinate.GetUpperBound( 0 ) + 1;
              for ( int i = 0; i < rows; i++ )
              {
                  mySeriesOfPoint.Points.AddXY( _harmonicChartCoordinate [ i, 0 ], _harmonicChartCoordinate [ i, 1 ] );
              }
              _chart.Series.Add( mySeriesOfPoint );
          }

          private void FillTable()
          {
              chartTableView.RowCount = COORDINATE_AMOUNT;
              chartTableView.ColumnCount = 2;
              chartTableView.Columns [ 0 ].HeaderText = "x";
              chartTableView.Columns [ 1 ].HeaderText = "y";
              int rows = _harmonicChartCoordinate.GetUpperBound( 0 ) + 1;
              int columns = _harmonicChartCoordinate.Length / rows;
              for ( int i = 0; i < rows; i++ )
              {
                  for ( int j = 0; j < columns; j++ )
                  {
                      chartTableView.Rows [ i ].Cells [ j ].Value = _harmonicChartCoordinate [ i, j ];
                  }
              }
          }

          private Chart CreateChart()
          {
              return new Chart
              {
                  Parent = tabPage1,
                  Dock = DockStyle.Fill
              };
          }*/

        private double? ProcessTextBoxStringValue( string value )
        {
            double result = 0;
            return double.TryParse( value, out result ) ? ( double? ) result : null;
        }

        private bool CanProcessTextBoxStringValue( TextBox textBox )
        {
            return textBox.Focused && !string.IsNullOrEmpty( textBox.Text ) && harmonicList.SelectedIndex != -1;
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

        private void EnableInputMethods(bool value)
        {
            amplitudeTextBox.Enabled = value;
            frequencyTextBox.Enabled = value;
            phaseTextBox.Enabled = value;
            sinRadioButton.Enabled = value;
            cosRadioButton.Enabled = value;
            deleteHarmonicButton.Enabled = value;
        }

        //event handlers

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
                var harmonicPresentation = _harmonicContainer.GetAllPresentation()[ harmonicList.SelectedIndex ];
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
            var frequencyValue = ProcessTextBoxStringValue( frequencyTextBox.Text );
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
            var phaseValue = ProcessTextBoxStringValue( phaseTextBox.Text );
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
            //  UpdateChartView();
            _harmonicContainerVizualization.UpdateVizualization();
            EnableInputMethods( false );
        }

        private void HarmonicList_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (harmonicList.Items.Count == 0)
            {
                EnableInputMethods( false );
            }
        }
    }
}