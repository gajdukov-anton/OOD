namespace WeatherStation.WeatherData
{
    public class StatisticInfo
    {
        private double _minValue = double.MaxValue;
        private double _maxValue = double.MinValue;
        private double _accValue = 0;

        public StatisticInfo()
        {
        }

        public void AddNewValue( double value )
        {
            if ( _minValue > value )
            {
                _minValue = value;
            }
            if ( _maxValue < value)
            {
                _maxValue = value;
            }
            _accValue += value;
        }

        public double GetMaxValue()
        {
            return _maxValue;
        }

        public double GetMinValue()
        {
            return _minValue;
        }

        public double GetAccValue()
        {
            return _accValue;
        }

    }
}
