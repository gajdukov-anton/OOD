using System;

namespace WeatherStation.WeatherData
{
    class WindStatisticHandler : IWindStatisticHandler
    {
        private double _accXValue = 0;
        private double _accYValue = 0;
        private double _accSpeedValue = 0;
        private double _minSpeedValue = double.MaxValue;
        private double _maxSpeedValue = double.MinValue;

        public WindStatisticHandler()
        {
        }

        public StatisticInfo CalculateWindDirectionStatisticInfo( int countAcc, WeatherInfo weatherInfo )
        {
            _accYValue += Math.Sin( weatherInfo.windInfo.windDirection * ( Math.PI / 180 ) ) * weatherInfo.windInfo.windSpeed;
            _accXValue += Math.Cos( weatherInfo.windInfo.windDirection * ( Math.PI / 180 ) ) * weatherInfo.windInfo.windSpeed;
            return new StatisticInfo( "wind direction" )
            {
                MaxValue = null,
                MinValue = null,
                AverageValue = GetAverangeDirectionFromVector( countAcc )
            };
        }

        public StatisticInfo CalculateWindSpeedStatisticInfo( int countAcc, WeatherInfo weatherInfo )
        {
            UpdateMinMaxValue( weatherInfo.windInfo.windSpeed );
            _accSpeedValue += weatherInfo.windInfo.windSpeed;
            return new StatisticInfo( "wind speed" )
            {
                MaxValue = _maxSpeedValue,
                MinValue = _minSpeedValue,
                AverageValue = _accSpeedValue / countAcc
            };
        }

        private double ValidateAngle( double angel )
        {
            if ( angel > 360 )
            {
                return 360;
            }
            else if ( angel < 0 )
            {
                return 0;
            }
            return angel;
        }

        private void UpdateMinMaxValue( double value )
        {
            if ( value > _maxSpeedValue )
            {
                _maxSpeedValue = value;
            }
            if ( value < _minSpeedValue )
            {
                _minSpeedValue = value;
            }
        }

        private bool IsZeroVector( double x, double y )
        {
            return Math.Abs( x ) < 0.01 && Math.Abs( y ) < 0.01;
        }

        private double? GetAverangeDirectionFromVector( int countAcc )
        {
            return IsZeroVector( _accXValue, _accYValue ) ? null : ( double? ) Math.Atan2( _accYValue / countAcc, _accXValue / countAcc ) * ( 180 / Math.PI );
        }
    }
}
