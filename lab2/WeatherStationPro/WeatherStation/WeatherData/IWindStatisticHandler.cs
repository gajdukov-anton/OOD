namespace WeatherStation.WeatherData
{
    public interface IWindStatisticHandler
    {
        StatisticInfo CalculateWindDirectionStatisticInfo( int countAcc, WeatherInfo weatherInfo );

        StatisticInfo CalculateWindSpeedStatisticInfo( int countAcc, WeatherInfo weatherInfo );

    }
}
