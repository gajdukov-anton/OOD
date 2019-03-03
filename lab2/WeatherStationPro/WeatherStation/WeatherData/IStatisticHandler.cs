namespace WeatherStation.WeatherData
{
    public interface IStatisticHandler
    {
        StatisticInfo CalculateStatisticInfo( int countAcc, double value = 0 );
    }
}
