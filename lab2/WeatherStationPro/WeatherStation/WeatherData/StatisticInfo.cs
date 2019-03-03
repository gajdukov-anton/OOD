
namespace WeatherStation.WeatherData
{
    public class StatisticInfo
    {
        public StatisticInfo(string entityName)
        {
            EntityName = entityName;
        }
        public double? MaxValue { get; set; }
        public double? MinValue { get; set; }
        public double? AverageValue { get; set; }
        public string EntityName { get; }
    }
}
