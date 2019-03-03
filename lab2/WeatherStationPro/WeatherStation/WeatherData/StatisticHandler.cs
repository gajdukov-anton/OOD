namespace WeatherStation.WeatherData
{
    public class StatisticHandler : IStatisticHandler
    {
        private double _minValue = double.MaxValue;
        private double _maxValue = double.MinValue;
        private double _accValue = 0;
        private string _entityName;

        public StatisticHandler( string entityName )
        {
            _entityName = entityName;
        }

        public StatisticInfo CalculateStatisticInfo( int countAcc, double value = 0 )
        {
            UpdateMinMaxValue( value );
            _accValue += value;
            return new StatisticInfo( _entityName )
            {
                MaxValue = _maxValue,
                MinValue = _minValue,
                AverageValue = _accValue / countAcc
            };
        }

        public void UpdateMinMaxValue( double value )
        {
            if ( value > _maxValue )
            {
                _maxValue = value;
            }
            if ( value < _minValue )
            {
                _minValue = value;
            }
        }

        public double GetMaxValue()
        {
            return _maxValue;
        }

        public double GetMinValue()
        {
            return _minValue;
        }

    }
}
