namespace WeatherStation.WeatherData
{
    public interface IWindStatisticHandler
    {
        StatisticInfo CalculateWindDirectionStatisticInfo( int countAcc, WeatherInfoOutside weatherInfo );

        StatisticInfo CalculateWindSpeedStatisticInfo( int countAcc, WeatherInfoOutside weatherInfo );

    }
}
