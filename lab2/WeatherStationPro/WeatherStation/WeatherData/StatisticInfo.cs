using System;

namespace WeatherStation.WeatherData
{
    public class StatisticInfo
    {
        public double AverageValue { get; set; }
        public double _minValue = double.MaxValue;
        public double _maxValue = double.MinValue;

        public StatisticInfo()
        {
        }

        public void SetMinMaxValue(double value)
        {
            if (value > _maxValue)
            {
                _maxValue = value;
            }
            if (value < _minValue)
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
