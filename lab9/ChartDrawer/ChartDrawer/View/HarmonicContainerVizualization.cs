using ChartDrawer.Model;
using ChartDrawer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartDrawer.View
{
    public class HarmonicContainerVizualization
    {
        private const double COORDINATE_STEP = 0.5;
        private const int COORDINATE_AMOUNT = 20;

        private double [,] _harmonicChartCoordinate;
        private IHarmonicContainerPresentation _harmonicContainer;
        private Chart _chart;
        private DataGridView _chartTableView;

        public HarmonicContainerVizualization( IHarmonicContainerPresentation harmonicContainer, TabPage tabPage, DataGridView chartTableView )
        {
            _harmonicContainer = harmonicContainer;
            _chart = new Chart
            {
                Parent = tabPage,
                Dock = DockStyle.Fill
            };
            _chartTableView = chartTableView;
            FillXCoordinate();
        }

        public void UpdateVizualization()
        {
            UpdateHarmonicChartYCoordinate();
            DrawChart();
            FillTable();
        }

        public void DrawChart()
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

        public void FillTable()
        {
            _chartTableView.RowCount = COORDINATE_AMOUNT;
            _chartTableView.ColumnCount = 2;
            _chartTableView.Columns [ 0 ].HeaderText = "x";
            _chartTableView.Columns [ 1 ].HeaderText = "y";
            int rows = _harmonicChartCoordinate.GetUpperBound( 0 ) + 1;
            int columns = _harmonicChartCoordinate.Length / rows;
            for ( int i = 0; i < rows; i++ )
            {
                for ( int j = 0; j < columns; j++ )
                {
                    _chartTableView.Rows [ i ].Cells [ j ].Value = _harmonicChartCoordinate [ i, j ];
                }
            }
        }

        public void UpdateHarmonicChartYCoordinate()
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
                    _harmonicChartCoordinate [ i, 1 ] += Math.Round( GetYValue( _harmonicChartCoordinate [ i, 0 ], harmonic ), 5 );
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
    }
}
