using ChartDrawer.Model;
using ChartDrawer.Util;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartDrawer.View
{
    public class HarmonicContainerVizualizer : IHarmonicContainerObserver
    {
        private const double COORDINATE_STEP = 0.05;
        private const int COORDINATE_AMOUNT = 100;

        private double [,] _harmonicChartCoordinate;
        private IHarmonicContainerPresentation _harmonicContainer;
        private Chart _chart;
        private DataGridView _tableView;

        public HarmonicContainerVizualizer( IHarmonicContainerPresentation harmonicContainer, TabPage tabPage, DataGridView tableView )
        {
            _harmonicContainer = harmonicContainer;
            _chart = new Chart
            {
                Parent = tabPage,
                Dock = DockStyle.Fill
            };
            _tableView = tableView;
            InitializeTable();
        }

        public void AddedNewHarmonic( int index )
        {
            AddCoordinateNewHarmonic( index );
        }

        public void RemovedHarmonic( int index )
        {
            Update();
        }

        public void Update()
        {
            UpdateHarmonicChartYCoordinate();
            DrawChart();
            FillTableYValue();
        }

        public void AddCoordinateNewHarmonic(int index)
        {
            var harmonics = _harmonicContainer.GetAllPresentation();
            AddHarmonicYCoordinate( harmonics [ index ] );
            DrawChart();
            FillTableYValue();
        }

        private void InitializeTable()
        {
            _harmonicChartCoordinate = new double [ COORDINATE_AMOUNT, 2 ];
            _tableView.RowCount = COORDINATE_AMOUNT;
            _tableView.ColumnCount = 2;
            _tableView.Columns [ 0 ].HeaderText = "x";
            _tableView.Columns [ 1 ].HeaderText = "y";
            double xValue = 0;
            for ( int i = 0; i < COORDINATE_AMOUNT; i++ )
            {
                _harmonicChartCoordinate [ i, 0 ] = Math.Round( xValue, 5 );
                xValue += COORDINATE_STEP;
            }
        }

        private void DrawChart()
        {
            _chart.Series.Clear();
            _chart.ChartAreas.Clear();
            _chart.ChartAreas.Add( new ChartArea( Constants.CHART_AREA_NAME ) );
            _chart.ChartAreas [ 0 ].AxisX.Minimum = 0;
            _chart.ChartAreas [ 0 ].AxisX.Maximum = COORDINATE_STEP * COORDINATE_AMOUNT;
            Series mySeriesOfPoint = new Series
            {
                ChartType = SeriesChartType.Spline,
                ChartArea = Constants.CHART_AREA_NAME
            };
            int rows = _harmonicChartCoordinate.GetUpperBound( 0 ) + 1;
            for ( int i = 0; i < rows; i++ )
            {
                mySeriesOfPoint.Points.AddXY( Math.Round(_harmonicChartCoordinate [ i, 0 ], 2), Math.Round(_harmonicChartCoordinate [ i, 1 ], 2) );
            }
            _chart.Series.Add( mySeriesOfPoint );
        }

        private void UpdateHarmonicChartYCoordinate()
        {
            ResetYCoordinate();
            var harmonics = _harmonicContainer.GetAllPresentation();
            foreach ( var harmonic in harmonics )
            {
                AddHarmonicYCoordinate( harmonic );
            }
        }

        private void ResetYCoordinate()
        {
            for ( int i = 0; i < COORDINATE_AMOUNT; i++ )
            {
                _harmonicChartCoordinate [ i, 1 ] = Math.Round( 0.0, 5 );
            }
        }

        private void AddHarmonicYCoordinate( IHarmonicPresentation harmonic )
        {
            for ( int i = 0; i < COORDINATE_AMOUNT; i++ )
            {
                _harmonicChartCoordinate [ i, 1 ] += Math.Round( GetYValue( _harmonicChartCoordinate [ i, 0 ], harmonic ), 5 );
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

        private void FillTableYValue()
        {
            int rows = _harmonicChartCoordinate.GetUpperBound( 0 ) + 1;
            int columns = _harmonicChartCoordinate.Length / rows;
            for ( int i = 0; i < rows; i++ )
            {
                for ( int j = 0; j < columns; j++ )
                {
                    _tableView.Rows [ i ].Cells [ j ].Value = _harmonicChartCoordinate [ i, j ];
                }
            }
        }
    }
}
